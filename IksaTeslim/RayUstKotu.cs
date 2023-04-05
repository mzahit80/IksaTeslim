using System;

namespace IksaTeslim
{
    class RayUstKotu
    {

        public static Double RayUstu(double km)
        {
            Double ruk = 0.0d;
            Double ilkSomekm = 113400.00d;
            Double ilkSomekot = 1055.893d;
            Double egim = -0.0019998344d;
            ruk = ilkSomekot + ((km - ilkSomekm) * egim) + 0.621;
            return ruk;

        }
    }
}
