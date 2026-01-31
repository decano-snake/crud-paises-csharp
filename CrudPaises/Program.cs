using CrudPaises.Data;
using CrudPaises.Models;
using System;
using System.Globalization;
using CrudPaises.Utils;

var repo = new PaisRepository();

// define decimal 
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

while (true)
{
    Console.Clear();
    Console.WriteLine("Cadastramento Países");
    Console.WriteLine("1 - Cadastrar país");
    Console.WriteLine("2 - Listar países");
    Console.WriteLine("3 - Editar país");
    Console.WriteLine("4 - Excluir país");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Cadastrar();
                break;
            case "2":
                Listar();
                break;
            case "3":
                Editar();
                break;
            case "4":
                Excluir();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("insira opção válida.");
                Pausa();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
        Pausa();
    }
}

void Cadastrar()
{
    Console.Clear();
    Console.WriteLine("Cadastrar país");

    Console.Write("Nome: ");
    var nome = InputHelp.LerNomePais("Nome: ");
    if (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome vázio.");
        Pausa();
        return;
    }

    long populacao = InputHelp.LerLong("População: ");
    double area = InputHelp.LerDouble("Área total: ");

    repo.Inserir(new Pais
    {
        Nome_pais = nome,
        Populacao = populacao,
        Area_total = area
    });

    Console.WriteLine("País cadastrado!");
    Pausa();
}

void Listar()
{
    Console.Clear();
    Console.WriteLine("Listagem de países");

    var lista = repo.Listar();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum país cadastrado.");
        Pausa();
        return;
    }

    Console.WriteLine("Codigo | Nome                          | População       | Área");
    Console.WriteLine("---------------------------------------------------------------");

    foreach (var p in lista)
    {
        Console.WriteLine($"{p.Codigo_pais,6} | {Truncar(p.Nome_pais, 28),-28} | {p.Populacao,14} | {p.Area_total}");
    }

    Pausa();
}

void Editar()
{
    Console.Clear();
    Console.WriteLine("Editar país");

    int codigo = InputHelp.LerInt("Código: ");

    var existente = repo.BuscarPorCodigo(codigo);
    if (existente == null)
    {
        Console.WriteLine("País não encontrado.");
        Pausa();
        return;
    }

    Console.WriteLine($"Atual: Nome={existente.Nome_pais}, População={existente.Populacao}, Área={existente.Area_total}");

    Console.Write("Novo nome: ");
    var nome = (Console.ReadLine() ?? "").Trim();
    if (!string.IsNullOrWhiteSpace(nome))
        existente.Nome_pais = nome;

    var popStr = LerOpcional("Nova população: ");
    if (!string.IsNullOrWhiteSpace(popStr))
        existente.Populacao = long.Parse(popStr);

    var areaStr = LerOpcional("Nova área total: ");
    if (!string.IsNullOrWhiteSpace(areaStr))
        existente.Area_total = double.Parse(areaStr, CultureInfo.InvariantCulture);

    bool ok = repo.Atualizar(existente);
    Console.WriteLine(ok ? "Atualizado" : "Nada atualizado.");
    Pausa();
}

void Excluir()
{
    Console.Clear();
    Console.WriteLine("Excluir país");

    int codigo = InputHelp.LerInt("Código: ");

    var existente = repo.BuscarPorCodigo(codigo);
    if (existente == null)
    {
        Console.WriteLine("País não encontrado.");
        Pausa();
        return;
    }

    Console.WriteLine($"País a ser excluído: {existente.Codigo_pais} - {existente.Nome_pais}");
    Console.Write("Confirma exclusão? (s/n): ");
    var conf = (Console.ReadLine() ?? "").Trim().ToLower();

    if (conf != "s")
    {
        Console.WriteLine("Exclusão cancelada.");
        Pausa();
        return;
    }

    bool ok = repo.Excluir(codigo);
    Console.WriteLine(ok ? "Excluído" : "Não excluidp.");
    Pausa();
}

int LerInt(string label)
{
    while (true)
    {
        Console.Write(label);
        var txt = (Console.ReadLine() ?? "").Trim();
        if (int.TryParse(txt, out int valor))
            return valor;

        Console.WriteLine("Inválido. Tente novamente.");
    }
}

long LerLong(string label)
{
    while (true)
    {
        Console.Write(label);
        var txt = (Console.ReadLine() ?? "").Trim();
        if (long.TryParse(txt, out long valor))
            return valor;

        Console.WriteLine("Inválido. Tente novamente.");
    }
}

double LerDouble(string label)
{
    while (true)
    {
        Console.Write(label);
        var txt = (Console.ReadLine() ?? "").Trim();

        // permite virgula/ponto
        txt = txt.Replace(',', '.');

        if (double.TryParse(txt, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
            return valor;

        Console.WriteLine("Inválido. Tente novamente.");
    }
}

string LerOpcional(string label)
{
    Console.Write(label);
    var txt = (Console.ReadLine() ?? "").Trim();
    return txt.Replace(',', '.');
}

string Truncar(string texto, int max)
{
    if (texto.Length <= max) return texto;
    return texto.Substring(0, max - 1) + "…";
}

void Pausa()
{
    Console.WriteLine();
    Console.Write("Pressione [ENTER]");
    Console.ReadKey();
}