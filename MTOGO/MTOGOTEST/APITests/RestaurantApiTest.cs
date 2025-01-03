// File: RestaurantApiTests.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MTOGO.Api;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api.Tests
{
    public class RestaurantApiTests
    {
        private readonly Mock<IFacadeFactory> _mockFacadeFactory;
        private readonly Mock<IRestaurantInterface> _mockRestaurantFacade;
        private readonly RestaurantApi _controller;

        public RestaurantApiTests()
        {
            _mockFacadeFactory = new Mock<IFacadeFactory>();
            _mockRestaurantFacade = new Mock<IRestaurantInterface>();

            // Setup the factory to return the mocked restaurant facade
            _mockFacadeFactory.Setup(f => f.GetResFacade()).Returns(_mockRestaurantFacade.Object);

            // Instantiate the controller with the mocked factory
            _controller = new RestaurantApi(_mockFacadeFactory.Object);
        }

        [Fact]
        public async Task GetRestaurants_ReturnsOkResult_WithListOfRestaurants()
        {
            // Arrange
            var restaurants = new List<RestaurantDTO>
            {
                new RestaurantDTO
                {
                    Id = 1,
                    Name = "Restaurant One",
                    Address = new AddressDTO
                    {
                        Id = 1,
                        Street = "123 Main St",
                        City = "Anytown",
                        ZipCode = "12345",
                        Region = "RegionA"
                    },
                    Rating = 4.5,
                    NumberOfRatings = 100,
                    CuisineType = "Italian",
                    Description = "A cozy Italian restaurant.",
                    PhoneNumber = "123-456-7890"
                },
                new RestaurantDTO
                {
                    Id = 2,
                    Name = "Restaurant Two",
                    Address = new AddressDTO
                    {
                        Id = 2,
                        Street = "456 Side St",
                        City = "Othertown",
                        ZipCode = "67890",
                        Region = "RegionB"
                    },
                    Rating = 4.0,
                    NumberOfRatings = 80,
                    CuisineType = "Mexican",
                    Description = "Authentic Mexican cuisine.",
                    PhoneNumber = "098-765-4321"
                }
            };

            _mockRestaurantFacade
                .Setup(facade => facade.GetRestaurants())
                .ReturnsAsync(restaurants);

            // Act
            var result = await _controller.GetRestaurants();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRestaurants = Assert.IsType<List<RestaurantDTO>>(okResult.Value);
            Assert.Equal(2, returnRestaurants.Count);
            Assert.Equal("Restaurant One", returnRestaurants[0].Name);
            Assert.Equal("Restaurant Two", returnRestaurants[1].Name);
        }

        [Fact]
        public async Task GetRestaurant_ReturnsOkResult_WithRestaurant()
        {
            // Arrange
            int restaurantId = 1;
            var restaurant = new RestaurantDTO
            {
                Id = restaurantId,
                Name = "Restaurant One",
                Address = new AddressDTO
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "Anytown",
                    ZipCode = "12345",
                    Region = "RegionA"
                },
                Rating = 4.5,
                NumberOfRatings = 100,
                CuisineType = "Italian",
                Description = "A cozy Italian restaurant.",
                PhoneNumber = "123-456-7890"
            };

            _mockRestaurantFacade
                .Setup(facade => facade.GetRestaurant(restaurantId))
                .ReturnsAsync(restaurant);

            // Act
            var result = await _controller.GetRestaurant(restaurantId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRestaurant = Assert.IsType<RestaurantDTO>(okResult.Value);
            Assert.Equal(restaurantId, returnRestaurant.Id);
            Assert.Equal("Restaurant One", returnRestaurant.Name);
        }

        [Fact]
        public async Task CreateRestaurant_ReturnsOkResult_WithCreatedRestaurant()
        {
            // Arrange
            var newRestaurant = new RestaurantDTO
            {
                Name = "New Restaurant",
                Address = new AddressDTO
                {
                    Street = "789 New St",
                    City = "Newcity",
                    ZipCode = "54321",
                    Region = "RegionC"
                },
                Rating = 0.0,
                NumberOfRatings = 0,
                CuisineType = "Japanese",
                Description = "Fresh sushi and more.",
                PhoneNumber = "555-555-5555"
            };

            var createdRestaurant = new RestaurantDTO
            {
                Id = 3,
                Name = "New Restaurant",
                Address = new AddressDTO
                {
                    Id = 3,
                    Street = "789 New St",
                    City = "Newcity",
                    ZipCode = "54321",
                    Region = "RegionC"
                },
                Rating = 0.0,
                NumberOfRatings = 0,
                CuisineType = "Japanese",
                Description = "Fresh sushi and more.",
                PhoneNumber = "555-555-5555"
            };

            _mockRestaurantFacade
                .Setup(facade => facade.CreateRestaurant(It.IsAny<RestaurantDTO>()))
                .ReturnsAsync(createdRestaurant);

            // Act
            var result = await _controller.CreateRestaurant(newRestaurant);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRestaurant = Assert.IsType<RestaurantDTO>(okResult.Value);
            Assert.Equal(3, returnRestaurant.Id);
            Assert.Equal("New Restaurant", returnRestaurant.Name);
            Assert.Equal("789 New St", returnRestaurant.Address.Street);
        }

        [Fact]
        public async Task UpdateRestaurant_ReturnsOkResult_WithUpdatedRestaurant()
        {
            // Arrange
            var updatedRestaurant = new RestaurantDTO
            {
                Id = 1,
                Name = "Updated Restaurant",
                Address = new AddressDTO
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "Anytown",
                    ZipCode = "12345",
                    Region = "RegionA"
                },
                Rating = 4.6,
                NumberOfRatings = 101,
                CuisineType = "Italian",
                Description = "An updated cozy Italian restaurant.",
                PhoneNumber = "123-456-7890"
            };

            _mockRestaurantFacade
                .Setup(facade => facade.UpdateRestaurant(It.IsAny<RestaurantDTO>()))
                .ReturnsAsync(updatedRestaurant);

            // Act
            var result = await _controller.UpdateRestaurant(updatedRestaurant);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRestaurant = Assert.IsType<RestaurantDTO>(okResult.Value);
            Assert.Equal(1, returnRestaurant.Id);
            Assert.Equal("Updated Restaurant", returnRestaurant.Name);
            Assert.Equal(4.6, returnRestaurant.Rating);
        }

        [Fact]
        public async Task CreateMenuItem_ReturnsOkResult_WithCreatedMenuItem()
        {
            // Arrange
            var newMenuItem = new MenuItemDTO
            {
                ItemName = "Sushi Platter",
                Price = 25.99,
                ItemDescription = "Assorted sushi rolls.",
                RestaurantId = 1,
                Image = "sushi.jpg"
            };

            var createdMenuItem = new MenuItemDTO
            {
                Id = 10,
                ItemName = "Sushi Platter",
                Price = 25.99,
                ItemDescription = "Assorted sushi rolls.",
                RestaurantId = 1,
                Image = "sushi.jpg"
            };

            _mockRestaurantFacade
                .Setup(facade => facade.CreateMenuItem(It.IsAny<MenuItemDTO>()))
                .ReturnsAsync(createdMenuItem);

            // Act
            var result = await _controller.CreateMenuItem(newMenuItem);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnMenuItem = Assert.IsType<MenuItemDTO>(okResult.Value);
            Assert.Equal(10, returnMenuItem.Id);
            Assert.Equal("Sushi Platter", returnMenuItem.ItemName);
            Assert.Equal(25.99, returnMenuItem.Price);
        }

        [Fact]
        public async Task UpdateMenuItem_ReturnsOkResult_WithUpdatedMenuItem()
        {
            // Arrange
            var updatedMenuItem = new MenuItemDTO
            {
                Id = 10,
                ItemName = "Updated Sushi Platter",
                Price = 27.99,
                ItemDescription = "Updated assortment of sushi rolls.",
                RestaurantId = 1,
                Image = "updated_sushi.jpg"
            };

            _mockRestaurantFacade
                .Setup(facade => facade.UpdateMenuItem(It.IsAny<MenuItemDTO>()))
                .ReturnsAsync(updatedMenuItem);

            // Act
            var result = await _controller.UpdateMenuItem(updatedMenuItem);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnMenuItem = Assert.IsType<MenuItemDTO>(okResult.Value);
            Assert.Equal(10, returnMenuItem.Id);
            Assert.Equal("Updated Sushi Platter", returnMenuItem.ItemName);
            Assert.Equal(27.99, returnMenuItem.Price);
        }

        [Fact]
        public async Task GetMenuItems_ReturnsOkResult_WithListOfMenuItems()
        {
            // Arrange
            int restaurantId = 1;
            var menuItems = new List<MenuItemDTO>
            {
                new MenuItemDTO
                {
                    Id = 10,
                    ItemName = "Sushi Platter",
                    Price = 25.99,
                    ItemDescription = "Assorted sushi rolls.",
                    RestaurantId = restaurantId,
                    Image = "sushi.jpg"
                },
                new MenuItemDTO
                {
                    Id = 11,
                    ItemName = "Ramen Bowl",
                    Price = 15.99,
                    ItemDescription = "Delicious ramen with toppings.",
                    RestaurantId = restaurantId,
                    Image = "ramen.jpg"
                }
            };

            _mockRestaurantFacade
                .Setup(facade => facade.GetMenuItems(restaurantId))
                .ReturnsAsync(menuItems);

            // Act
            var result = await _controller.GetMenuItems(restaurantId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnMenuItems = Assert.IsType<List<MenuItemDTO>>(okResult.Value);
            Assert.Equal(2, returnMenuItems.Count);
            Assert.Equal("Sushi Platter", returnMenuItems[0].ItemName);
            Assert.Equal("Ramen Bowl", returnMenuItems[1].ItemName);
        }
    }
}
