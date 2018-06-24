using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BlogApi.Controllers
{
    public class PostsController : ApiController
    {
        [ResponseType(typeof(List<PostModel>))]
        public IHttpActionResult Get()
        {
            var posts = new List<PostModel>
            {
                new PostModel()
                {
                    Id = 4,
                    Title = "Get your Connected Product to Market Faster",
                    Content = "OST has a long history helping clients imagine, build, and run their own amazing connected products. From smart office furniture to air purifiers, we’ve supported organizations at all points of the IoT lifecycle. While the recipe for a successful IoT project can vary, there are three ingredients found within all successful product launches: agility, stability, and security.",
                    Image = "https://www.ostusa.com/wp-content/uploads/2018/05/iot-foundation-feature-image.jpg",
                    DateCreated = DateTime.Now.AddDays(-45)
                },

                new PostModel()
                {
                    Id = 3,
                    Title = "Designing for Viability: Business Journey Maps",
                    Content = @"Knowing the limits of innovation that a company will embrace, support and execute is critical to the design process. Innovation that is too small won’t add value. Innovation that is too big isn’t actionable.
                                The design community tends to hyper-focus on the user and the technology but become fuzzy on how to customize a solution to the current business context. Understanding the user and technology is the core competency of design. However, design problems don’t stop there. Innovation needs inputs from the broader context – desirability (the user), feasibility (the technology) and viability (the business).",
                    Image = "https://www.ostusa.com/wp-content/uploads/2017/09/AAEAAQAAAAAAAAW9AAAAJDdhOGJlMTNhLWI1YWMtNDJlOS04Y2Y2LWUwNmNhNzZkNTljMw.jpg",
                    DateCreated = DateTime.Now.AddDays(-85)
                },

                new PostModel()
                {
                    Id = 2,
                    Title = "As an organization matures, IT's role shifts",
                    Content = "In today’s evolving business landscape, it seems that every organization is a tech company. As technology continues to be a deeply integrated part of our lives, everyone is exploring ways to incorporate it into product and processes to increase value. As a result, the responsibility for tech no longer lives solely with the IT department. We recently spoke with Michael Lomonaco, OST Director of marketing and communications, and Brian Hauch, OST Design Director, about the changing IT landscape and what to expect in the future.",
                    Image = "https://www.ostusa.com/wp-content/uploads/2018/01/IT-shifts-image-e1516812214273.jpg",
                    DateCreated = DateTime.Now.AddDays(-105)
                },

                new PostModel()
                {
                    Id = 1,
                    Title = "The Best IT Conference No One Goes To",
                    Content = "I recently attended the Hawaii International Conference on System Sciences (HICSS) on the island of Hawaii. Yes, I said an IT conference on Hawaii the first week of January. Far from the wintry climes of my native Michigan and lake effect snow.",
                    Image = "https://www.ostusa.com/wp-content/uploads/2018/01/Hawaii1.jpg",
                    DateCreated = DateTime.Now.AddDays(-125)
                }
            };


            return Ok(posts.OrderByDescending(x => x.DateCreated));
        }

        // POST: api/dealers
        [ResponseType(typeof(PostModel))]
        [HttpPost]
        public IHttpActionResult Post(PostModel post)
        {
            Random rnd = new Random();
            return Ok(new PostModel()
            {
                Id = rnd.Next(),
                Title = post.Title,
                Content = post.Content,
                Image = post.Image,
                DateCreated = DateTime.Now
            });
        }
    }
}
