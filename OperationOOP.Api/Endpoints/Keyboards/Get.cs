namespace OperationOOP.Api.Endpoints;

public class GetKeyboards : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/keyboards/{id}", Handle)
        .WithSummary("Keyboards");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        KeyboardFormfactor? FormFactor,
        KeyCapProfile? KeyCapProfile,
        KeyCapMaterial? KeyCapMaterial,
        KeySwitch? KeySwitch,
        bool HasBluetooth,
        bool HasRGB
        );

    private static IResult Handle([AsParameters] Request request, ProductContext db)
    {
        var keyboard = db.PurchasableProducts
            .OfType<Keyboard>()
            .FirstOrDefault(item => item.Id == request.Id);
        if (keyboard is null) 
            return Results.NotFound();

        var response = new Response(
               Id: keyboard.Id,
               Name: keyboard.Name,
               Manufacturer: keyboard.Manufacturer,
               ManufacturersId: keyboard.ManufacturersId,
               InStock: keyboard.InStock,
               Price: keyboard.Price,
               FormFactor: keyboard.KeyboardFormfactor,
               KeyCapProfile: keyboard.KeyCapProfile,
               KeyCapMaterial: keyboard.KeyCapMaterial,
               KeySwitch: keyboard.KeySwitch,
               HasBluetooth: keyboard.HasBluetooth,
               HasRGB: keyboard.HasRGB
               );

        return Results.Ok(response);
    }


}
