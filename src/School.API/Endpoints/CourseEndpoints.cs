using Microsoft.AspNetCore.Mvc;
using School.API.ApplicationCore.Interfaces;
using School.API.Data.DTOs;
using School.API.Data.Entities;

namespace School.API.Endpoints;

public static class CourseEndpoints
{

    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(CoursesRoutes.Prefix).WithTags(nameof(Course));

        _ = group.MapGet(CoursesRoutes.Root, async ([FromServices] ICoursesBusiness coursesBusiness) =>
        {
            return Results.Ok(await coursesBusiness.GetAllCourses());
        })
          .AllowAnonymous()
          .WithName("GetAllCourses")
          .Produces<ApiResponseDto<IReadOnlyCollection<CourseDto>>>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status500InternalServerError)
          .WithOpenApi();

        _ = group.MapGet(CoursesRoutes.ActionById, async ([FromRoute] Guid courseId, [FromServices] ICoursesBusiness coursesBusiness) =>
        {
            var result = await coursesBusiness.GetById(courseId);
            if (!result.Success)
            {
                return Results.NotFound(result);
            }
            return Results.Ok(result);
        })
        .AllowAnonymous()
        .WithName("GetCourseById")
        .Produces<ApiResponseDto<CourseDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();
    }

}
