using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("0196bccc-38a1-4949-a554-e21230efe398"),
                    Name = "Apple iPhone 15 Pro",
                    Description = "The latest iPhone with A17 chip and titanium design.",
                    Category = new List<string> { "Electronics", "Phone" },
                    ImageFile = "iphone15pro.jpg",
                    Price = 1200m
                },
                new Product
                {
                    Id = Guid.Parse("c3e839f5-7b02-4a4b-9807-d019b3cb3dc1"),
                    Name = "Samsung QLED 4K TV",
                    Description = "65-inch smart QLED TV with vibrant colors and streaming support.",
                    Category = new List<string> { "Electronics", "Television" },
                    ImageFile = "samsung_qled_tv.jpg",
                    Price = 999.99m
                },
                new Product
                {
                    Id = Guid.Parse("563b8412-e5dc-4f7d-a929-8c7459f8743f"),
                    Name = "Sony WH-1000XM5",
                    Description = "Industry-leading noise canceling wireless headphones.",
                    Category = new List<string> { "Electronics", "Audio" },
                    ImageFile = "sony_wh1000xm5.jpg",
                    Price = 349.99m
                },
                new Product
                {
                    Id = Guid.Parse("2b12e8b4-0644-41fd-9a67-e4db64a6e79e"),
                    Name = "Dell XPS 15",
                    Description = "High-performance laptop with 4K display and Intel i9 processor.",
                    Category = new List<string> { "Electronics", "Laptop" },
                    ImageFile = "dell_xps_15.jpg",
                    Price = 1899.00m
                },
                new Product
                {
                    Id = Guid.Parse("b768f098-31a7-45c6-9c61-28728b83914f"),
                    Name = "Instant Pot Duo 7-in-1",
                    Description = "Multifunctional pressure cooker with 13 customizable programs.",
                    Category = new List<string> { "Home Appliances", "Kitchen" },
                    ImageFile = "instant_pot_duo.jpg",
                    Price = 89.95m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Nike Air Max 270",
                    Description = "Stylish and comfortable running shoes with air cushioning.",
                    Category = new List<string> { "Fashion", "Footwear" },
                    ImageFile = "nike_air_max_270.jpg",
                    Price = 150.00m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Logitech MX Master 3S",
                    Description = "Advanced wireless mouse with ergonomic design and fast scrolling.",
                    Category = new List<string> { "Electronics", "Accessories" },
                    ImageFile = "logitech_mx_master_3s.jpg",
                    Price = 99.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Amazon Echo Dot (5th Gen)",
                    Description = "Smart speaker with Alexa and improved sound quality.",
                    Category = new List<string> { "Electronics", "Smart Home" },
                    ImageFile = "echo_dot_5th_gen.jpg",
                    Price = 49.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Fitbit Charge 6",
                    Description = "Fitness tracker with heart rate, GPS, and sleep tracking.",
                    Category = new List<string> { "Fitness", "Wearables" },
                    ImageFile = "fitbit_charge_6.jpg",
                    Price = 129.95m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Kindle Paperwhite",
                    Description = "Waterproof e-reader with high-resolution display and long battery life.",
                    Category = new List<string> { "Electronics", "Reading" },
                    ImageFile = "kindle_paperwhite.jpg",
                    Price = 139.99m
                }
            };
        }
    }
}
