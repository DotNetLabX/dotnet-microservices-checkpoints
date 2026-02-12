using Auth.Domain.Persons;
using Auth.Grpc;
using Mapster;

namespace Auth.API.Features.Persons;

public class GrpcTypeAdapterConfig : TypeAdapterConfig
{
    public GrpcTypeAdapterConfig()
    {
        this.NewConfig<Person, PersonInfo>()
            .Map(dest => dest.Honorific, src => src.Honorific == null ? null : src.Honorific.Value)
            .IgnoreNullValues(true); //mapster might have problems managing null values.

        // this might nor be neccessary, maspster should know to map it since both have the same properties
        this.NewConfig<Auth.Domain.Persons.ValueObjects.ProfessionalProfile, ProfessionalProfile>();
    }
}
