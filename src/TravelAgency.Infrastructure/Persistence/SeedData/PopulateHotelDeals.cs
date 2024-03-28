using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateHotelDeals(AeroSkullDbContext context)
    {
        if (context.HotelDeals.Any())
            return;

        var random = new Random(0);
        var hotelIds = context.Hotels
            .Select(hotel => hotel.Id)
            .ToList();
        if(hotelIds.Count == 0)
            throw new Exception("There are no hotels");

        context.HotelDeals.AddRange(
            new HotelDeal()
            {
                Id = Guid.NewGuid(),
                Name = "Deal Name 1",
                Description = "Estancia en el hotel con acceso gratuito al bar en la azotea para la mejor vista del descubrimiento de meteoros Perseidas y un menú especial con platos temáticos de estrellas",
                Price = 155,
                ArrivalDate = new DateTime(2024, 8, 4),
                DepartureDate = new DateTime(2024, 8, 24),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal()
            {
                Id = Guid.NewGuid(),
                Name = "Deal Name 2",
                Description = "Descubra la historia local con nuestras visitas guiadas a los monumentos históricos de la ciudad",
                Price = 150,
                ArrivalDate = new DateTime(2024, 9, 1),
                DepartureDate = new DateTime(2024, 9, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal()
            {
                Id = Guid.NewGuid(),
                Name = "Deal Name 3",
                Description = "Disfrute de una escapada romántica con nuestro paquete especial que incluye una cena para dos y un paseo a la luz de la luna",
                Price = 175,
                ArrivalDate = new DateTime(2024, 9, 16),
                DepartureDate = new DateTime(2024, 9, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal()
            {
                Id = Guid.NewGuid(),
                Name = "Deal Name 4",
                Description = "Viva la emoción de las fiestas locales con nuestro paquete especial que incluye entradas para los eventos y transporte",
                Price = 190,
                ArrivalDate = new DateTime(2024, 12, 16),
                DepartureDate = new DateTime(2024, 12, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 5",
                Description = "Disfrute de una estancia mágica con vistas al mar y cenas a la luz de las velas en la playa",
                Price = 200,
                ArrivalDate = new DateTime(2024, 8, 1),
                DepartureDate = new DateTime(2024, 8, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 6",
                Description = "Relájese en nuestro spa de lujo y disfrute de tratamientos rejuvenecedores",
                Price = 220,
                ArrivalDate = new DateTime(2024, 8, 16),
                DepartureDate = new DateTime(2024, 8, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 7",
                Description = "Experimente la serenidad de las montañas con nuestro paquete de retiro de yoga y meditación",
                Price = 180,
                ArrivalDate = new DateTime(2024, 12, 1),
                DepartureDate = new DateTime(2024, 12, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 8",
                Description = "Disfrute de una estancia mágica con vistas al mar y cenas a la luz de las velas en la playa. Incluye un tour de snorkel gratuito.",
                Price = 200,
                ArrivalDate = new DateTime(2024, 8, 1),
                DepartureDate = new DateTime(2024, 8, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 9",
                Description = "Relájese en nuestro spa de lujo y disfrute de tratamientos rejuvenecedores. Incluye desayuno buffet diario.",
                Price = 180,
                ArrivalDate = new DateTime(2024, 8, 16),
                DepartureDate = new DateTime(2024, 8, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 10",
                Description = "Experimente la emoción de nuestras excursiones de senderismo y ciclismo de montaña. Incluye picnic gourmet en la cima de la montaña.",
                Price = 150,
                ArrivalDate = new DateTime(2024, 9, 1),
                DepartureDate = new DateTime(2024, 9, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 11",
                Description = "Aprenda a cocinar platos locales con nuestro famoso chef. Incluye una botella de vino de cortesía.",
                Price = 220,
                ArrivalDate = new DateTime(2024, 9, 16),
                DepartureDate = new DateTime(2024, 9, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 12",
                Description = "Descubra la rica historia y cultura de la ciudad con nuestro tour guiado. Incluye entradas a todos los museos y sitios históricos.",
                Price = 190,
                ArrivalDate = new DateTime(2024, 10, 1),
                DepartureDate = new DateTime(2024, 10, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 13",
                Description = "Disfrute de una escapada romántica con nuestro paquete de luna de miel. Incluye una cena privada en la playa y un masaje en pareja.",
                Price = 250,
                ArrivalDate = new DateTime(2024, 10, 16),
                DepartureDate = new DateTime(2024, 10, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 14",
                Description = "Viva la aventura con nuestro paquete de deportes acuáticos. Incluye lecciones de surf y alquiler de equipo de buceo.",
                Price = 210,
                ArrivalDate = new DateTime(2024, 11, 1),
                DepartureDate = new DateTime(2024, 11, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 15",
                Description = "Disfrute de la tranquilidad con nuestro paquete de yoga y meditación. Incluye clases diarias de yoga y meditación al amanecer.",
                Price = 160,
                ArrivalDate = new DateTime(2024, 11, 16),
                DepartureDate = new DateTime(2024, 11, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 16",
                Description = "Sumérgete en la cultura local con nuestro paquete de arte y música. Incluye entradas a conciertos y galerías de arte locales.",
                Price = 175,
                ArrivalDate = new DateTime(2024, 12, 1),
                DepartureDate = new DateTime(2024, 12, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 17",
                Description = "Vive la emoción de la vida salvaje con nuestro paquete de safari. Incluye un tour guiado por el parque nacional cercano.",
                Price = 230,
                ArrivalDate = new DateTime(2024, 12, 16),
                DepartureDate = new DateTime(2024, 12, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 18",
                Description = "Disfruta de la tranquilidad del campo con nuestro paquete de retiro rural. Incluye clases de pintura al aire libre y degustación de vinos locales.",
                Price = 195,
                ArrivalDate = new DateTime(2025, 1, 1),
                DepartureDate = new DateTime(2025, 1, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 19",
                Description = "Experimenta la adrenalina con nuestro paquete de deportes extremos. Incluye lecciones de parapente y rafting.",
                Price = 210,
                ArrivalDate = new DateTime(2025, 1, 16),
                DepartureDate = new DateTime(2025, 1, 30),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            },
            new HotelDeal(){
                Id = Guid.NewGuid(),
                Name = "Deal Name 20",
                Description = "Descubre los secretos del mar con nuestro paquete de buceo. Incluye lecciones de buceo y exploración de arrecifes de coral.",
                Price = 220,
                ArrivalDate = new DateTime(2025, 2, 1),
                DepartureDate = new DateTime(2025, 2, 15),
                HotelId = hotelIds[random.Next(0, hotelIds.Count - 1)]
            }
        );

        context.SaveChanges();
    }
}