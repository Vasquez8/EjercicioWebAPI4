using System;

namespace JDVA_11092024.Auth;

public interface IJwtAuthenticatioService
{
    string Authenticate(string userName);
}
