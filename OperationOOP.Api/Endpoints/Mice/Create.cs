namespace OperationOOP.Api.Endpoints.Mice;

public class CreateMouse : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/mice", Handle)
        .WithSummary("Computer Mice");

    public record Request(
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        MotionDetection MotionDetection,
        bool IsUsableWithLeftHand = true,
        bool HasBluetooth = false
        );

    public record Response(int id);

    private static Ok<Response> Handle(Request request, ProductContext db)
    {
        var mouse = new Mouse();
        mouse.Id = db.PurchasableProducts.OfType<Mouse>().Any()
            ? db.PurchasableProducts.OfType<Mouse>().Max(x => x.Id) + 1
            : 1;
        mouse.Name = request.Name;
        mouse.Manufacturer = request.Manufacturer;
        mouse.ManufacturersId = request.ManufacturersId;
        mouse.InStock = request.InStock;
        mouse.Price = request.Price;
        mouse.MotionDetection = request.MotionDetection;
        mouse.IsUsableWithLeftHand = request.IsUsableWithLeftHand;
        mouse.HasBluetooth = request.HasBluetooth;

        db.Add(mouse);
        db.SaveChanges();
        return TypedResults.Ok(new Response(mouse.Id));

    }



}
