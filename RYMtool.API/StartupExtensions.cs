using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.API;

public static class StartupExtensions
{
    public static IApplicationBuilder AddSeedData(this IApplicationBuilder applicationBuilder)
    {
        var services = applicationBuilder.ApplicationServices;
        var lifetime = services.GetRequiredService<IHostApplicationLifetime>();
        lifetime.ApplicationStarted.Register(
            () =>
            {
                async Task SeedData()
                {
                    using var ser = applicationBuilder.ApplicationServices.CreateScope();
                    var repository = ser.ServiceProvider.GetRequiredService<IRepository<Album>>();
                    
                    await repository.AddRangeAsync(new List<Album>
                    {
                        new ()  {
                            Id = 1,
                            Artist = "mbv",
                            Descriptors = "sad",
                            Cover = "",
                            Genre = "shoegaze",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 1,
                                    Score = 5
                                },
                                new()
                                {
                                    Id = 2,
                                    Score = 4
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 1,
                                    Message = "good",
                                    Reviewer = "user1"
                                },
                                new()
                                {
                                    Id = 2,
                                    Reviewer = "user2",
                                    Message = "average"
                                }
                            },
                            Title = "loveless"
                        },
                        new()
                        {
                            Id = 2,
                            Artist = "the cure",
                            Descriptors = "dark",
                            Cover = "",
                            Genre = "post-punk",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 3,
                                    Score = 5
                                },
                                new()
                                {
                                    Id = 4,
                                    Score = 4
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 3,
                                    Message = "not bad",
                                    Reviewer = "user3"
                                },
                                new()
                                {
                                    Id = 4,
                                    Reviewer = "cool",
                                    Message = "user4"
                                }
                            },
                            Title = "faith"
                        },
                        new()
                        {
                            Id = 3,
                            Artist = "mineral",
                            Descriptors = "melancholy",
                            Cover = "",
                            Genre = "midwest emo",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 5,
                                    Score = 3
                                },
                                new()
                                {
                                    Id = 6,
                                    Score = 5
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 5,
                                    Message = "average",
                                    Reviewer = "user5"
                                },
                                new()
                                {
                                    Id = 6,
                                    Reviewer = "user6",
                                    Message = "perfect"
                                }
                            },
                            Title = "the power of failing"
                        }
                        
                    }
                    );
                }

                _ = SeedData();
            });
        return applicationBuilder;
    }
}