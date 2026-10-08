using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

//http://localhost:5062
app.MapGet("/", () => "API do Ecommerce");

//http://localhost:5062/produtos/cadastrar
app.MapPost("/api/produtos/cadastrar", ([FromBody] Produto? produtoCadastrar) =>
{
    if(produtoCadastrar == null)
        Results.BadRequest("Produto Inválido!");
});

app.MapPost("/api/produto/cadastrar", ([FromBody] Produto? produto, [FromServices] AppDataContext ctx) =>
{
    if(produto is null)
        return Results.BadRequest("Produto inválido");
    
    if (string.IsNullOrEmpty(produto.Nome))
        return Results.BadRequest("O nome do produto é obrigatório");
    
    if (ctx.Produtos.FirstOrDefault(produtosCadastrados => produtosCadastrados.Nome == produto.Nome) != null)
        return Results.BadRequest("Esse produto já foi cadastrado");

    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});


app.Run();