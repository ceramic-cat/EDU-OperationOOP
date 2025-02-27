namespace OperationOOP.Api.Endpoints.Mousepads;

public class CreateMousepad : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/mousepads", Handle)
        .WithSummary("Mousepads");

    public record Request(
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        int Width,
        int Height,
        string Color = "Black"
        );

    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var mousepad = new Mousepad();
        mousepad.Id = db.Mousepads.Any()
            ? db.Mousepads.Max(x => x.Id) + 1
            : 1;
        mousepad.Name = request.Name;
        mousepad.Manufacturer = request.Manufacturer;
        mousepad.ManufacturersId = request.ManufacturersId;
        mousepad.InStock = request.InStock;
        mousepad.Price = request.Price;
        mousepad.Width = request.Width;
        mousepad.Height = request.Height;
        mousepad.Color = request.Color;

        db.Mousepads.Add(mousepad);

        return TypedResults.Ok(new Response(mousepad.Id));

    }
}
