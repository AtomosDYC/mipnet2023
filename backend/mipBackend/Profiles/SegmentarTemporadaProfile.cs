using AutoMapper;
using mipBackend.Dtos.TemporadaDtos;
using mipBackend.Models;

namespace mipBackend.Profiles
{
    public class SegmentarTemporadaProfile : Profile
    {
        public SegmentarTemporadaProfile()
        {

            CreateMap<Temp03Segmentacion, SegmentarTemporadaResponseDto>();
            CreateMap<SegmentarTemporadaResponseDto, Temp03Segmentacion>();
            CreateMap<SegmentarTemporadaRequestDto, Temp03Segmentacion>();

        }
    }
}
