using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Enums
{
    public enum CashPaymentEnum
    {
        /// <summary>
        /// Efecty
        /// </summary>
        EF,
        /// <summary>
        /// Gana - monto minimo 2000
        /// </summary>
        GA,
        /// <summary>
        /// Punto red - monto minimo 10000
        /// </summary>
        PR,
        /// <summary>
        /// Red Servi - monto minimo 10000
        /// </summary>
        RS,
        /// <summary>
        /// Sured - monto minimo 2000
        /// </summary>
        SR
    }
}
