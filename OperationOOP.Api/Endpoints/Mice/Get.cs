namespace OperationOOP.Api.Endpoints.Mice;
public class GetMice : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mice/{id}", Handle)
        .WithSummary("Computer Mice");

    public record Request(int Id);

    public record Response(
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        MotionDetection MotionDetection,
        bool IsUsableWithLeftHand,
        bool HasBluetooth
        );

    private static IResult Handle([AsParameters] Request request, ProductContext db)
    {
        var mouse = db.PurchasableProducts.OfType<Mouse>()
            .FirstOrDefault(item => item.Id == request.Id);
        if (mouse is null) return Results.NotFound();

        var response = new Response(
               Name: mouse.Name,
               Manufacturer: mouse.Manufacturer,
               ManufacturersId: mouse.ManufacturersId,
               InStock: mouse.InStock,
               Price: mouse.Price,
               MotionDetection: mouse.MotionDetection,
               IsUsableWithLeftHand: mouse.IsUsableWithLeftHand,
               HasBluetooth: mouse.HasBluetooth
               );

        return Results.Ok(response);
    }


}
