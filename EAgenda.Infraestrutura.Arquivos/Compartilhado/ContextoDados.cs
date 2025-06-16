using System.Text.Json.Serialization;
using System.Text.Json;
using EAgenda.Dominio.ModuloCategoria;

namespace EAgenda.Infraestrutura.Arquivos.Compartilhado;

public class ContextoDados
{
    private string pastaRaiz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AcademiaProgramador2025");
    private string arquivoArmazenamento = "dados.json";
    private string pastaPrincipal = "EAgenda";

    public List<Categoria> Categorias { get; set; }

    public ContextoDados()
    {
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        if (!Directory.Exists(pastaRaiz))
            Directory.CreateDirectory(pastaRaiz);

        string pastaProjeto = Path.Combine(pastaRaiz, pastaPrincipal);

        if (!Directory.Exists(pastaProjeto))
            Directory.CreateDirectory(pastaProjeto);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string caminhoCompleto = Path.Combine(pastaProjeto, arquivoArmazenamento);

        string json = JsonSerializer.Serialize(this, jsonOptions);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string pastaProjeto = Path.Combine(pastaRaiz, pastaPrincipal);

        string caminhoCompleto = Path.Combine(pastaProjeto, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(
            json,
            jsonOptions
        )!;

        if (contextoArmazenado == null) return;

        Categorias = contextoArmazenado.Categorias;
    }
}
