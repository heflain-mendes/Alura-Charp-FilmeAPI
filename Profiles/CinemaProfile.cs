using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile() {
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>()
            .ForMember(
                cinemaDTO => cinemaDTO.Endereco, 
                opts => opts.MapFrom(cinema => cinema.Endereco)
            )
            .ForMember(
                cinemaDTO => cinemaDTO.Sessoes,
                opts => opts.MapFrom(cinema => cinema.Sessoes)
            );
        CreateMap<UpdateCinemaDTO, Cinema>();
    }
}
