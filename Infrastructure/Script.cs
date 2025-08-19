//using Refit;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure
//{
//    internal class Script
//static async Task Main(string[] args)
//    {
//        //await RefitRestTestPost();
//        await RefitRestGeoCode();
//    }

//    private static async Task RefitRestGeoCode()
//    {
//        var api = RestService.For<IGeoCodeMapApi>("https://geocode.maps.co");
//        //GeocodeMapsApiKey apikey = new GeocodeMapsApiKey();
//        //Console.WriteLine(apikey.ApiKey);
//        var address = await api.SearchAddressAsync("-37.3159", "81.1496", "68a3482a29ad9257102219mgv7b655b");
//        Console.WriteLine(address);
//    }

//    private static async Task RefitRestTestPost()
//    {
//        var api = RestService.For<IJsonPlaceholderApi>("https://jsonplaceholder.typicode.com");
//        ///Get all posts
//        List<Post> postList = new List<Post>();
//        postList = await api.GetPostsAsync();
//        foreach (Post p in postList)
//            Console.WriteLine($"Post {p.Id}: {p.Title}");
//        Console.WriteLine("=-=-=-=-=-=-=-=-=-=");

//        ///Get Post by id.
//        var post = await api.GetPostByIdAsync(1);
//        Console.WriteLine($"Post {post.Id}: {post.Title}");
//        Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
//        ///Create Post.
//        var newPost = await api.CreatePostAsync(new Post
//        {
//            UserId = 1,
//            Title = "My test post",
//            Body = "Post body"
//        });
//        Console.WriteLine($"Novo post criado com Id {newPost.Id}");
//        Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
//        ///Update Post with Put
//        var selectedId = 1;
//        var updatededPost = new Post
//        {
//            UserId = 1,
//            Title = "My updatade test post",
//            Body = "Its is the nem body of post"
//        };
//        var oldPost = await api.GetPostByIdAsync(selectedId);
//        var updatePost = await api.UpdatePostAsync(selectedId, updatededPost);
//        Console.WriteLine($"The post with Id {selectedId} with the properties:" +
//            $"\nUserId:{oldPost.UserId}," +
//            $"\nTitle:{oldPost.Title}," +
//            $"\nBody:{oldPost.Body}" +
//            $"\n Has been updated to these new properties:" +
//            $"\nUserId:{updatePost.UserId}," +
//            $"\nTitle:{updatePost.Title}," +
//            $"\nBody:{updatePost.Body}");
//        Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
//        ///Update Post with Patch
//        var change = new { title = "Changed" };
//        var patchPost = await api.ParcialUpdateAsync(selectedId, change);
//        Console.WriteLine($"The post id {selectedId} with Title: {oldPost.Title}\n" +
//            $"had its title changed to: {change.title}");
//        Console.WriteLine("=-=-=-=-=-=-=-=-=-=");
//        ///Delete post
//    }

//    private static async Task RestSharpTest()
//    {

//    }

//    private static async Task HttpClientTest()
//    {

//    }
//}
