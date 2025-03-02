namespace OperationOOP.Api.Endpoints.Keyboards;

public class CreateKeyboard : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/keyboards", Handle)
        .WithSummary("Keyboards");

    public record Request(
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        KeyboardFormfactor? Formfactor,
        KeyCapProfile? KeyCapProfile,
        KeyCapMaterial? KeyCapMaterial,
        KeySwitch? KeySwitch,
        bool HasRGB = false,
        bool HasBluetooth = false
        );

    public record Response(int id);

    private static Ok<Response> Handle(Request request, ProductContext db)
    {
        var keyboard = new Keyboard();
        keyboard.Id = db.PurchasableProducts.Any()
            ? db.PurchasableProducts.Max(x => x.Id) + 1
            : 1;

        keyboard.Name = request.Name;
        keyboard.Manufacturer = request.Manufacturer;
        keyboard.ManufacturersId = request.ManufacturersId;
        keyboard.InStock = request.InStock;
        keyboard.Price = request.Price;
        keyboard.KeyboardFormfactor = request.Formfactor;
        keyboard.KeyCapProfile = request.KeyCapProfile;
        keyboard.KeyCapMaterial = request.KeyCapMaterial;
        keyboard.KeySwitch = request.KeySwitch;
        keyboard.HasRGB = request.HasRGB;
        keyboard.HasBluetooth = request.HasBluetooth;
        
        db.Add(keyboard);
        db.SaveChanges();

        return TypedResults.Ok(new Response(keyboard.Id));

    }



}
