using Mapster;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.Business;
using Movie.Business.DTO;

namespace Movie.API;
public class Mapper
{
    public static void MapsterInit()
    {
        TypeAdapterConfig<MovieDTO, MovieResponse>.NewConfig();

        TypeAdapterConfig<MovieRequest, MovieDetailDTO>.NewConfig()
        .Map(dest => dest.UserId, src => src.UserId)
        .Map(dest => dest.MovieId, src => src.Movie.Id)
        .Map(dest => dest.Description, src => src.Movie.Description)
        .Map(dest => dest.Title, src => src.Movie.Title);

        TypeAdapterConfig<WatchListDTO, WatchListDetailResponse>.NewConfig()
        .Map(dest => dest.MovieId, src => src.Id);
    }
}
