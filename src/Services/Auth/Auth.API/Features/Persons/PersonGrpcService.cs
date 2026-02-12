using Auth.Grpc;
using Auth.Persistence.Repositories;
using Mapster;
using ProtoBuf.Grpc;

namespace Auth.API.Features.Persons;

public class PersonGrpcService(PersonRepository _personRepository, GrpcTypeAdapterConfig _typeAdapterConfig) : IPersonService
{
    public async ValueTask<GetPersonResponse> GetPersonByUserIdAsync(GetPersonByUserIdRequest request, CallContext context = default)
    {
        var person = Guard.NotFound(
            await _personRepository.GetByUserIdAsync(request.UserId, context.CancellationToken)
            );

        return new GetPersonResponse
        {
            PersonInfo = person.Adapt<PersonInfo>(_typeAdapterConfig)
        };
    }
}
