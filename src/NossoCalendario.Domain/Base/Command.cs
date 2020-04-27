using MediatR;
using System;


namespace NossoCalendario.Domain.Base
{
    public abstract class Command : IRequest<Response>
    {

    }
}
