using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Facades;

namespace MTOGOTEST
{
    public class RestaurantFacadeTests
    {
        [Fact]
        public async Task GetRestaurants_ShouldReturnListOfRestaurantDTO_OnSuccess()
        {
            // Arrange
            var expectedRestaurants = new List<RestaurantDTO>
            {
                new RestaurantDTO(1, "Pizza Place", new AddressDTO(1, "123 Main St", "Anytown", "12345", "Region A"),
                    4.5, 100, "Italian", "Best pizza in town.", "555-1234"),
                new RestaurantDTO(2, "Sushi Spot", new AddressDTO(2, "456 Elm St", "Othertown", "67890", "Region B"),
                    4.8, 150, "Japanese", "Fresh sushi daily.", "555-5678")
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedRestaurants), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == "/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.GetRestaurants();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRestaurants.Count, result.Count);
            for (int i = 0; i < expectedRestaurants.Count; i++)
            {
                Assert.Equal(expectedRestaurants[i].Id, result[i].Id);
                Assert.Equal(expectedRestaurants[i].Name, result[i].Name);
                Assert.Equal(expectedRestaurants[i].Address.Id, result[i].Address.Id);
                Assert.Equal(expectedRestaurants[i].Rating, result[i].Rating);
                Assert.Equal(expectedRestaurants[i].NumberOfRatings, result[i].NumberOfRatings);
                Assert.Equal(expectedRestaurants[i].CuisineType, result[i].CuisineType);
                Assert.Equal(expectedRestaurants[i].Description, result[i].Description);
                Assert.Equal(expectedRestaurants[i].PhoneNumber, result[i].PhoneNumber);
            }

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == "/"),
                ItExpr.IsAny<CancellationToken>()
            );
        }


        [Fact]
        public async Task GetRestaurant_ShouldReturnRestaurantDTO_OnSuccess()
        {
            // Arrange
            int restaurantId = 1;
            var expectedRestaurant = new RestaurantDTO(
                1,
                "Pizza Place",
                new AddressDTO(1, "123 Main St", "Anytown", "12345", "Region A"),
                4.5,
                100,
                "Italian",
                "Best pizza in town.",
                "555-1234"
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedRestaurant), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/{restaurantId}"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.GetRestaurant(restaurantId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRestaurant.Id, result.Id);
            Assert.Equal(expectedRestaurant.Name, result.Name);
            Assert.Equal(expectedRestaurant.Address.Id, result.Address.Id);
            Assert.Equal(expectedRestaurant.Rating, result.Rating);
            Assert.Equal(expectedRestaurant.NumberOfRatings, result.NumberOfRatings);
            Assert.Equal(expectedRestaurant.CuisineType, result.CuisineType);
            Assert.Equal(expectedRestaurant.Description, result.Description);
            Assert.Equal(expectedRestaurant.PhoneNumber, result.PhoneNumber);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/{restaurantId}"),
                ItExpr.IsAny<CancellationToken>()
            );
        }


        [Fact]
        public async Task CreateRestaurant_ShouldReturnCreatedRestaurantDTO_OnSuccess()
        {
            // Arrange
            var restaurantToCreate = new RestaurantDTO
            {
                Name = "Burger Joint",
                Address = new AddressDTO("789 Oak St", "Newcity", "54321", "Region C"),
                Rating = 4.2,
                NumberOfRatings = 50,
                CuisineType = "American",
                Description = "Delicious burgers and fries.",
                PhoneNumber = "555-9012"
            };

            var createdRestaurant = new RestaurantDTO(
                3,
                restaurantToCreate.Name,
                restaurantToCreate.Address,
                restaurantToCreate.Rating,
                restaurantToCreate.NumberOfRatings,
                restaurantToCreate.CuisineType,
                restaurantToCreate.Description,
                restaurantToCreate.PhoneNumber
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(createdRestaurant), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.CreateRestaurant(restaurantToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdRestaurant.Id, result.Id);
            Assert.Equal(createdRestaurant.Name, result.Name);
            Assert.Equal(createdRestaurant.Address.Id, result.Address.Id);
            Assert.Equal(createdRestaurant.Rating, result.Rating);
            Assert.Equal(createdRestaurant.NumberOfRatings, result.NumberOfRatings);
            Assert.Equal(createdRestaurant.CuisineType, result.CuisineType);
            Assert.Equal(createdRestaurant.Description, result.Description);
            Assert.Equal(createdRestaurant.PhoneNumber, result.PhoneNumber);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/"),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task UpdateRestaurant_ShouldReturnUpdatedRestaurantDTO_OnSuccess()
        {
            // Arrange
            var restaurantToUpdate = new RestaurantDTO
            {
                Id = 1,
                Name = "Pizza Place Updated",
                Address = new AddressDTO(1, "123 Main St", "Anytown", "12345", "Region A"),
                Rating = 4.6,
                NumberOfRatings = 105,
                CuisineType = "Italian",
                Description = "Updated description.",
                PhoneNumber = "555-1234"
            };

            var updatedRestaurant = new RestaurantDTO(
                restaurantToUpdate.Id,
                restaurantToUpdate.Name,
                restaurantToUpdate.Address,
                restaurantToUpdate.Rating,
                restaurantToUpdate.NumberOfRatings,
                restaurantToUpdate.CuisineType,
                restaurantToUpdate.Description,
                restaurantToUpdate.PhoneNumber
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(updatedRestaurant), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.UpdateRestaurant(restaurantToUpdate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedRestaurant.Id, result.Id);
            Assert.Equal(updatedRestaurant.Name, result.Name);
            Assert.Equal(updatedRestaurant.Address.Id, result.Address.Id);
            Assert.Equal(updatedRestaurant.Rating, result.Rating);
            Assert.Equal(updatedRestaurant.NumberOfRatings, result.NumberOfRatings);
            Assert.Equal(updatedRestaurant.CuisineType, result.CuisineType);
            Assert.Equal(updatedRestaurant.Description, result.Description);
            Assert.Equal(updatedRestaurant.PhoneNumber, result.PhoneNumber);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/"),
                ItExpr.IsAny<CancellationToken>()
            );
        }


        [Fact]
        public async Task CreateMenuItem_ShouldReturnCreatedMenuItemDTO_OnSuccess()
        {
            // Arrange
            var menuItemToCreate = new MenuItemDTO
            {
                ItemName = "Cheeseburger",
                Price = 9.99,
                ItemDescription = "Juicy beef patty with cheese.",
                RestaurantId = 1,
                Image = "cheeseburger.jpg"
            };

            var createdMenuItem = new MenuItemDTO(
                1,
                menuItemToCreate.ItemName,
                menuItemToCreate.Price,
                menuItemToCreate.ItemDescription,
                menuItemToCreate.RestaurantId,
                menuItemToCreate.Image
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(createdMenuItem), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/menuitem"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.CreateMenuItem(menuItemToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdMenuItem.Id, result.Id);
            Assert.Equal(createdMenuItem.ItemName, result.ItemName);
            Assert.Equal(createdMenuItem.Price, result.Price);
            Assert.Equal(createdMenuItem.ItemDescription, result.ItemDescription);
            Assert.Equal(createdMenuItem.RestaurantId, result.RestaurantId);
            Assert.Equal(createdMenuItem.Image, result.Image);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/menuitem"),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task UpdateMenuItem_ShouldReturnUpdatedMenuItemDTO_OnSuccess()
        {
            // Arrange
            var menuItemToUpdate = new MenuItemDTO
            {
                Id = 1,
                ItemName = "Cheeseburger Deluxe",
                Price = 11.99,
                ItemDescription = "Extra cheese and bacon added.",
                RestaurantId = 1,
                Image = "cheeseburger_deluxe.jpg"
            };

            var updatedMenuItem = new MenuItemDTO(
                menuItemToUpdate.Id,
                menuItemToUpdate.ItemName,
                menuItemToUpdate.Price,
                menuItemToUpdate.ItemDescription,
                menuItemToUpdate.RestaurantId,
                menuItemToUpdate.Image
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(updatedMenuItem), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/menuitem"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.UpdateMenuItem(menuItemToUpdate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedMenuItem.Id, result.Id);
            Assert.Equal(updatedMenuItem.ItemName, result.ItemName);
            Assert.Equal(updatedMenuItem.Price, result.Price);
            Assert.Equal(updatedMenuItem.ItemDescription, result.ItemDescription);
            Assert.Equal(updatedMenuItem.RestaurantId, result.RestaurantId);
            Assert.Equal(updatedMenuItem.Image, result.Image);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/menuitem"),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetMenuItems_ShouldReturnListOfMenuItemDTO_OnSuccess()
        {
            // Arrange
            int restaurantId = 1;
            var expectedMenuItems = new List<MenuItemDTO>
            {
                new MenuItemDTO(1, "Cheeseburger", 9.99, "Juicy beef patty with cheese.", restaurantId,
                    "cheeseburger.jpg"),
                new MenuItemDTO(2, "Veggie Burger", 8.99, "Delicious plant-based patty.", restaurantId,
                    "veggieburger.jpg")
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedMenuItems), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/menuitems/{restaurantId}"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            var result = await restaurantFacade.GetMenuItems(restaurantId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMenuItems.Count, result.Count);
            for (int i = 0; i < expectedMenuItems.Count; i++)
            {
                Assert.Equal(expectedMenuItems[i].Id, result[i].Id);
                Assert.Equal(expectedMenuItems[i].ItemName, result[i].ItemName);
                Assert.Equal(expectedMenuItems[i].Price, result[i].Price);
                Assert.Equal(expectedMenuItems[i].ItemDescription, result[i].ItemDescription);
                Assert.Equal(expectedMenuItems[i].RestaurantId, result[i].RestaurantId);
                Assert.Equal(expectedMenuItems[i].Image, result[i].Image);
            }

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/menuitems/{restaurantId}"),
                ItExpr.IsAny<CancellationToken>()
            );
        }


        [Fact]
        public async Task UpdateRestaurantRating_ShouldCompleteSuccessfully_OnSuccess()
        {
            // Arrange
            var ratingDto = new UpdateRatingDTO(1, 4.5, 100);

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/rating"),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var restaurantFacade = new RestaurantFacade(httpClient);

            // Act
            await restaurantFacade.UpdateRestaurantRating(ratingDto);

            // Assert
            // If no exception is thrown, the test passes

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/rating"),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}