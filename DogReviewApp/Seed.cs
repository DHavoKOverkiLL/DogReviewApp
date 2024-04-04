using DogReviewApp.Data;
using DogReviewApp.Models;

namespace DogReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.DogOwner.Any())
            {
                var dogOwners = new List<DogOwner>()
                {
                    new DogOwner()
                    {
                        Dog = new Dog()
                        {
                            Name = "Marshmellow",
                            BirthDate = new DateTime(1903,1,1),
                            DogCategories = new List<DogCategory>()
                            {
                                new DogCategory { Category = new Category() { Name = "Toy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Marshmellow",Text = "Marshmellow is the best dog, because it is a toy",},
                                new Review { Title="Marshmellow", Text = "Marshmellow is the best at licking rocks",},
                                new Review { Title="Marshmellow",Text = "Marshmellow, marshmellow, marshmellow",},
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            Club = "Brocks Club",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new DogOwner()
                    {
                        Dog = new Dog()
                        {
                            Name = "Turty",
                            BirthDate = new DateTime(1903,1,1),
                            DogCategories = new List<DogCategory>()
                            {
                                new DogCategory { Category = new Category() { Name = "Working"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Turty", Text = "Turty is the best pokemon, because it is electric",},
                                new Review { Title= "Turty",Text = "Turty is the best a killing rocks" },
                                new Review { Title= "Turty", Text = "Turty, Turty, Turty" },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            Club = "Mistys Club",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new DogOwner()
                    {
                        Dog = new Dog()
                        {
                            Name = "Bory",
                            BirthDate = new DateTime(1903,1,1),
                            DogCategories = new List<DogCategory>()
                            {
                                new DogCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Bory",Text = "Bory is the best pokemon, because it is electric" },
                                new Review { Title="Bory",Text = "Bory is the best at biting mailmen" },
                                new Review { Title="Bory",Text = "Bory, Bory, Bory" },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash",
                            Club = "Ashs Club",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.DogOwner.AddRange(dogOwners);
                dataContext.SaveChanges();
            }
        }
    }
}