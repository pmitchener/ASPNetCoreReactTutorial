using aspnetserver.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

//need to add CORS so that our react app can communicate without security error.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        policy =>
        {
            policy
            .WithOrigins("http://localhost:3000", "https://lively-island-055d66e10.2.azurestaticapps.net")
            .AllowAnyMethod()
            .AllowAnyHeader();     
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ASP .NET React Tutorial", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//want this to show up in all dev environment
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI(swaggerGenOptions =>
{
    swaggerGenOptions.DocumentTitle = "ASP .NET React Tutorial";
    swaggerGenOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post Model.");
    swaggerGenOptions.RoutePrefix = String.Empty;
});
//modify Properties.launchSettings.json. remove the launchUrl lines so that our app starts without a launch URL

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");//make sure "CORSPolicy" is same name as above setup.

//add end-points
app.MapGet("/get-all-posts", async () => await PostRepository.GetPostsAsync())
    .WithTags("Posts Endpoints");//this is the endpoint to get all the posts.


app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    Post post = await PostRepository.GetPostByIdAsync(postId);
    return post != null ? Results.Ok(post) : Results.BadRequest();
    /*if(post != null)
    {
        return Results.Ok(post);
    }
    else
    {
       return Results.BadRequest(); 
    }*/
}).WithTags("Posts Endpoints");

app.MapPost("/create-post", async (Post post) =>
{
    return await PostRepository.CreatePostAync(post) ? Results.Ok("Create successful") : Results.BadRequest();
    /*bool bSuccess = await PostRepository.CreatePostAync(post);
    if (bSuccess)
    {
        return Results.Ok("Create successful");
    }
    else
    {
        return Results.BadRequest();
    }*/
}).WithTags("Posts Endpoints");

app.MapPut("/update-post", async (Post post) =>
{
    return await PostRepository.UpdatePostAync(post) ? Results.Ok("Update successful") : Results.BadRequest();
    /*bool bSuccess = await PostRepository.UpdatePostAync(post);
    if (bSuccess)
    {
        return Results.Ok("Update successful");
    }
    else
    {
        return Results.BadRequest();
    }*/
}).WithTags("Posts Endpoints");

app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
{
    return await PostRepository.DeletePostAync(postId) ? Results.Ok("Delete successful") : Results.BadRequest();
    /*bool bSuccess = await PostRepository.DeletePostAync(postId);
    if (bSuccess)
    {
        return Results.Ok("Delete successful");
    }
    else
    {
        return Results.BadRequest();
    }*/
}).WithTags("Posts Endpoints");

app.Run();