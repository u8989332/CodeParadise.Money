using System;
using System.Collections.Generic;

namespace CodeParadise.Core
{
    /// <summary>
    /// References
    /// Currency names: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?view=net-5.0
    /// The number of digit: https://en.wikipedia.org/wiki/ISO_4217
    /// </summary>
    public readonly struct Currency : IEquatable<Currency>
    {
        /// Currency name: UAE Dirham
        private const string AED_NAME = "AED";

        /// Currency name: Albanian Lek
        private const string ALL_NAME = "ALL";

        /// Currency name: Armenian Dram
        private const string AMD_NAME = "AMD";

        /// Currency name: Argentine Peso
        private const string ARS_NAME = "ARS";

        /// Currency name: Australian Dollar
        private const string AUD_NAME = "AUD";

        /// Currency name: Azerbaijanian Manat
        private const string AZN_NAME = "AZN";

        /// Currency name: Bulgarian Lev
        private const string BGN_NAME = "BGN";

        /// Currency name: Bahraini Dinar
        private const string BHD_NAME = "BHD";

        /// Currency name: Brunei Dollar
        private const string BND_NAME = "BND";

        /// Currency name: Boliviano
        private const string BOB_NAME = "BOB";

        /// Currency name: Real
        private const string BRL_NAME = "BRL";

        /// Currency name: Belarussian Ruble
        private const string BYR_NAME = "BYR";

        /// Currency name: Belize Dollar
        private const string BZD_NAME = "BZD";

        /// Currency name: Canadian Dollar
        private const string CAD_NAME = "CAD";

        /// Currency name: Swiss Franc
        private const string CHF_NAME = "CHF";

        /// Currency name: Chilean Peso
        private const string CLP_NAME = "CLP";

        /// Currency name: PRC Renminbi
        private const string CNY_NAME = "CNY";

        /// Currency name: Colombian Peso
        private const string COP_NAME = "COP";

        /// Currency name: Costa Rican Colon
        private const string CRC_NAME = "CRC";

        /// Currency name: Czech Koruna
        private const string CZK_NAME = "CZK";

        /// Currency name: Danish Krone
        private const string DKK_NAME = "DKK";

        /// Currency name: Dominican Peso
        private const string DOP_NAME = "DOP";

        /// Currency name: Algerian Dinar
        private const string DZD_NAME = "DZD";

        /// Currency name: Estonian Kroon
        private const string EEK_NAME = "EEK";

        /// Currency name: Egyptian Pound
        private const string EGP_NAME = "EGP";

        /// Currency name: Ethiopian Birr
        private const string ETB_NAME = "ETB";

        /// Currency name: Euro
        private const string EUR_NAME = "EUR";

        /// Currency name: UK Pound Sterling
        private const string GBP_NAME = "GBP";

        /// Currency name: Lari
        private const string GEL_NAME = "GEL";

        /// Currency name: Guatemalan Quetzal
        private const string GTQ_NAME = "GTQ";

        /// Currency name: Hong Kong Dollar
        private const string HKD_NAME = "HKD";

        /// Currency name: Honduran Lempira
        private const string HNL_NAME = "HNL";

        /// Currency name: Croatian Kuna
        private const string HRK_NAME = "HRK";

        /// Currency name: Hungarian Forint
        private const string HUF_NAME = "HUF";

        /// Currency name: Indonesian Rupiah
        private const string IDR_NAME = "IDR";

        /// Currency name: Israeli New Shekel
        private const string ILS_NAME = "ILS";

        /// Currency name: Indian Rupee
        private const string INR_NAME = "INR";

        /// Currency name: Iraqi Dinar
        private const string IQD_NAME = "IQD";

        /// Currency name: Iranian Rial
        private const string IRR_NAME = "IRR";

        /// Currency name: Icelandic Krona
        private const string ISK_NAME = "ISK";

        /// Currency name: Jamaican Dollar
        private const string JMD_NAME = "JMD";

        /// Currency name: Jordanian Dinar
        private const string JOD_NAME = "JOD";

        /// Currency name: Japanese Yen
        private const string JPY_NAME = "JPY";

        /// Currency name: Kenyan Shilling
        private const string KES_NAME = "KES";

        /// Currency name: som
        private const string KGS_NAME = "KGS";

        /// Currency name: Korean Won
        private const string KRW_NAME = "KRW";

        /// Currency name: Kuwaiti Dinar
        private const string KWD_NAME = "KWD";

        /// Currency name: Tenge
        private const string KZT_NAME = "KZT";

        /// Currency name: Lebanese Pound
        private const string LBP_NAME = "LBP";

        /// Currency name: Lithuanian Litas
        private const string LTL_NAME = "LTL";

        /// Currency name: Latvian Lats
        private const string LVL_NAME = "LVL";

        /// Currency name: Libyan Dinar
        private const string LYD_NAME = "LYD";

        /// Currency name: Moroccan Dirham
        private const string MAD_NAME = "MAD";

        /// Currency name: Macedonian Denar
        private const string MKD_NAME = "MKD";

        /// Currency name: Tugrik
        private const string MNT_NAME = "MNT";

        /// Currency name: Macao Pataca
        private const string MOP_NAME = "MOP";

        /// Currency name: Rufiyaa
        private const string MVR_NAME = "MVR";

        /// Currency name: Mexican Peso
        private const string MXN_NAME = "MXN";

        /// Currency name: Malaysian Ringgit
        private const string MYR_NAME = "MYR";

        /// Currency name: Nicaraguan Cordoba Oro
        private const string NIO_NAME = "NIO";

        /// Currency name: Norwegian Krone
        private const string NOK_NAME = "NOK";

        /// Currency name: New Zealand Dollar
        private const string NZD_NAME = "NZD";

        /// Currency name: Omani Rial
        private const string OMR_NAME = "OMR";

        /// Currency name: Panamanian Balboa
        private const string PAB_NAME = "PAB";

        /// Currency name: Peruvian Nuevo Sol
        private const string PEN_NAME = "PEN";

        /// Currency name: Philippine Peso
        private const string PHP_NAME = "PHP";

        /// Currency name: Pakistan Rupee
        private const string PKR_NAME = "PKR";

        /// Currency name: Polish Zloty
        private const string PLN_NAME = "PLN";

        /// Currency name: Paraguay Guarani
        private const string PYG_NAME = "PYG";

        /// Currency name: Qatari Rial
        private const string QAR_NAME = "QAR";

        /// Currency name: Romanian Leu
        private const string RON_NAME = "RON";

        /// Currency name: Serbian Dinar
        private const string RSD_NAME = "RSD";

        /// Currency name: Russian Ruble
        private const string RUB_NAME = "RUB";

        /// Currency name: Saudi Riyal
        private const string SAR_NAME = "SAR";

        /// Currency name: Swedish Krona
        private const string SEK_NAME = "SEK";

        /// Currency name: Singapore Dollar
        private const string SGD_NAME = "SGD";

        /// Currency name: Syrian Pound
        private const string SYP_NAME = "SYP";

        /// Currency name: Thai Baht
        private const string THB_NAME = "THB";

        /// Currency name: Tunisian Dinar
        private const string TND_NAME = "TND";

        /// Currency name: Turkish Lira
        private const string TRY_NAME = "TRY";

        /// Currency name: Trinidad Dollar
        private const string TTD_NAME = "TTD";

        /// Currency name: New Taiwan Dollar
        private const string TWD_NAME = "TWD";

        /// Currency name: Ukrainian Hryvnia
        private const string UAH_NAME = "UAH";

        /// Currency name: US Dollar
        private const string USD_NAME = "USD";

        /// Currency name: Peso Uruguayo
        private const string UYU_NAME = "UYU";

        /// Currency name: Uzbekistan Som
        private const string UZS_NAME = "UZS";

        /// Currency name: Venezuelan Bolivar
        private const string VEF_NAME = "VEF";

        /// Currency name: Vietnamese Dong
        private const string VND_NAME = "VND";

        /// Currency name: Yemeni Rial
        private const string YER_NAME = "YER";

        /// Currency name: South African Rand
        private const string ZAR_NAME = "ZAR";

        /// Currency name: Zimbabwe Dollar
        private const string ZWL_NAME = "ZWL";

        /// Currency instance: UAE Dirham
        public static readonly Currency AED = new Currency(AED_NAME);

        /// Currency instance: Albanian Lek
        public static readonly Currency ALL = new Currency(ALL_NAME);

        /// Currency instance: Armenian Dram
        public static readonly Currency AMD = new Currency(AMD_NAME);

        /// Currency instance: Argentine Peso
        public static readonly Currency ARS = new Currency(ARS_NAME);

        /// Currency instance: Australian Dollar
        public static readonly Currency AUD = new Currency(AUD_NAME);

        /// Currency instance: Azerbaijanian Manat
        public static readonly Currency AZN = new Currency(AZN_NAME);

        /// Currency instance: Bulgarian Lev
        public static readonly Currency BGN = new Currency(BGN_NAME);

        /// Currency instance: Bahraini Dinar
        public static readonly Currency BHD = new Currency(BHD_NAME);

        /// Currency instance: Brunei Dollar
        public static readonly Currency BND = new Currency(BND_NAME);

        /// Currency instance: Boliviano
        public static readonly Currency BOB = new Currency(BOB_NAME);

        /// Currency instance: Real
        public static readonly Currency BRL = new Currency(BRL_NAME);

        /// Currency instance: Belarussian Ruble
        public static readonly Currency BYR = new Currency(BYR_NAME);

        /// Currency instance: Belize Dollar
        public static readonly Currency BZD = new Currency(BZD_NAME);

        /// Currency instance: Canadian Dollar
        public static readonly Currency CAD = new Currency(CAD_NAME);

        /// Currency instance: Swiss Franc
        public static readonly Currency CHF = new Currency(CHF_NAME);

        /// Currency instance: Chilean Peso
        public static readonly Currency CLP = new Currency(CLP_NAME);

        /// Currency instance: PRC Renminbi
        public static readonly Currency CNY = new Currency(CNY_NAME);

        /// Currency instance: Colombian Peso
        public static readonly Currency COP = new Currency(COP_NAME);

        /// Currency instance: Costa Rican Colon
        public static readonly Currency CRC = new Currency(CRC_NAME);

        /// Currency instance: Czech Koruna
        public static readonly Currency CZK = new Currency(CZK_NAME);

        /// Currency instance: Danish Krone
        public static readonly Currency DKK = new Currency(DKK_NAME);

        /// Currency instance: Dominican Peso
        public static readonly Currency DOP = new Currency(DOP_NAME);

        /// Currency instance: Algerian Dinar
        public static readonly Currency DZD = new Currency(DZD_NAME);

        /// Currency instance: Estonian Kroon
        public static readonly Currency EEK = new Currency(EEK_NAME);

        /// Currency instance: Egyptian Pound
        public static readonly Currency EGP = new Currency(EGP_NAME);

        /// Currency instance: Ethiopian Birr
        public static readonly Currency ETB = new Currency(ETB_NAME);

        /// Currency instance: Euro
        public static readonly Currency EUR = new Currency(EUR_NAME);

        /// Currency instance: UK Pound Sterling
        public static readonly Currency GBP = new Currency(GBP_NAME);

        /// Currency instance: Lari
        public static readonly Currency GEL = new Currency(GEL_NAME);

        /// Currency instance: Guatemalan Quetzal
        public static readonly Currency GTQ = new Currency(GTQ_NAME);

        /// Currency instance: Hong Kong Dollar
        public static readonly Currency HKD = new Currency(HKD_NAME);

        /// Currency instance: Honduran Lempira
        public static readonly Currency HNL = new Currency(HNL_NAME);

        /// Currency instance: Croatian Kuna
        public static readonly Currency HRK = new Currency(HRK_NAME);

        /// Currency instance: Hungarian Forint
        public static readonly Currency HUF = new Currency(HUF_NAME);

        /// Currency instance: Indonesian Rupiah
        public static readonly Currency IDR = new Currency(IDR_NAME);

        /// Currency instance: Israeli New Shekel
        public static readonly Currency ILS = new Currency(ILS_NAME);

        /// Currency instance: Indian Rupee
        public static readonly Currency INR = new Currency(INR_NAME);

        /// Currency instance: Iraqi Dinar
        public static readonly Currency IQD = new Currency(IQD_NAME);

        /// Currency instance: Iranian Rial
        public static readonly Currency IRR = new Currency(IRR_NAME);

        /// Currency instance: Icelandic Krona
        public static readonly Currency ISK = new Currency(ISK_NAME);

        /// Currency instance: Jamaican Dollar
        public static readonly Currency JMD = new Currency(JMD_NAME);

        /// Currency instance: Jordanian Dinar
        public static readonly Currency JOD = new Currency(JOD_NAME);

        /// Currency instance: Japanese Yen
        public static readonly Currency JPY = new Currency(JPY_NAME);

        /// Currency instance: Kenyan Shilling
        public static readonly Currency KES = new Currency(KES_NAME);

        /// Currency instance: som
        public static readonly Currency KGS = new Currency(KGS_NAME);

        /// Currency instance: Korean Won
        public static readonly Currency KRW = new Currency(KRW_NAME);

        /// Currency instance: Kuwaiti Dinar
        public static readonly Currency KWD = new Currency(KWD_NAME);

        /// Currency instance: Tenge
        public static readonly Currency KZT = new Currency(KZT_NAME);

        /// Currency instance: Lebanese Pound
        public static readonly Currency LBP = new Currency(LBP_NAME);

        /// Currency instance: Lithuanian Litas
        public static readonly Currency LTL = new Currency(LTL_NAME);

        /// Currency instance: Latvian Lats
        public static readonly Currency LVL = new Currency(LVL_NAME);

        /// Currency instance: Libyan Dinar
        public static readonly Currency LYD = new Currency(LYD_NAME);

        /// Currency instance: Moroccan Dirham
        public static readonly Currency MAD = new Currency(MAD_NAME);

        /// Currency instance: Macedonian Denar
        public static readonly Currency MKD = new Currency(MKD_NAME);

        /// Currency instance: Tugrik
        public static readonly Currency MNT = new Currency(MNT_NAME);

        /// Currency instance: Macao Pataca
        public static readonly Currency MOP = new Currency(MOP_NAME);

        /// Currency instance: Rufiyaa
        public static readonly Currency MVR = new Currency(MVR_NAME);

        /// Currency instance: Mexican Peso
        public static readonly Currency MXN = new Currency(MXN_NAME);

        /// Currency instance: Malaysian Ringgit
        public static readonly Currency MYR = new Currency(MYR_NAME);

        /// Currency instance: Nicaraguan Cordoba Oro
        public static readonly Currency NIO = new Currency(NIO_NAME);

        /// Currency instance: Norwegian Krone
        public static readonly Currency NOK = new Currency(NOK_NAME);

        /// Currency instance: New Zealand Dollar
        public static readonly Currency NZD = new Currency(NZD_NAME);

        /// Currency instance: Omani Rial
        public static readonly Currency OMR = new Currency(OMR_NAME);

        /// Currency instance: Panamanian Balboa
        public static readonly Currency PAB = new Currency(PAB_NAME);

        /// Currency instance: Peruvian Nuevo Sol
        public static readonly Currency PEN = new Currency(PEN_NAME);

        /// Currency instance: Philippine Peso
        public static readonly Currency PHP = new Currency(PHP_NAME);

        /// Currency instance: Pakistan Rupee
        public static readonly Currency PKR = new Currency(PKR_NAME);

        /// Currency instance: Polish Zloty
        public static readonly Currency PLN = new Currency(PLN_NAME);

        /// Currency instance: Paraguay Guarani
        public static readonly Currency PYG = new Currency(PYG_NAME);

        /// Currency instance: Qatari Rial
        public static readonly Currency QAR = new Currency(QAR_NAME);

        /// Currency instance: Romanian Leu
        public static readonly Currency RON = new Currency(RON_NAME);

        /// Currency instance: Serbian Dinar
        public static readonly Currency RSD = new Currency(RSD_NAME);

        /// Currency instance: Russian Ruble
        public static readonly Currency RUB = new Currency(RUB_NAME);

        /// Currency instance: Saudi Riyal
        public static readonly Currency SAR = new Currency(SAR_NAME);

        /// Currency instance: Swedish Krona
        public static readonly Currency SEK = new Currency(SEK_NAME);

        /// Currency instance: Singapore Dollar
        public static readonly Currency SGD = new Currency(SGD_NAME);

        /// Currency instance: Syrian Pound
        public static readonly Currency SYP = new Currency(SYP_NAME);

        /// Currency instance: Thai Baht
        public static readonly Currency THB = new Currency(THB_NAME);

        /// Currency instance: Tunisian Dinar
        public static readonly Currency TND = new Currency(TND_NAME);

        /// Currency instance: Turkish Lira
        public static readonly Currency TRY = new Currency(TRY_NAME);

        /// Currency instance: Trinidad Dollar
        public static readonly Currency TTD = new Currency(TTD_NAME);

        /// Currency instance: New Taiwan Dollar
        public static readonly Currency TWD = new Currency(TWD_NAME);

        /// Currency instance: Ukrainian Hryvnia
        public static readonly Currency UAH = new Currency(UAH_NAME);

        /// Currency instance: US Dollar
        public static readonly Currency USD = new Currency(USD_NAME);

        /// Currency instance: Peso Uruguayo
        public static readonly Currency UYU = new Currency(UYU_NAME);

        /// Currency instance: Uzbekistan Som
        public static readonly Currency UZS = new Currency(UZS_NAME);

        /// Currency instance: Venezuelan Bolivar
        public static readonly Currency VEF = new Currency(VEF_NAME);

        /// Currency instance: Vietnamese Dong
        public static readonly Currency VND = new Currency(VND_NAME);

        /// Currency instance: Yemeni Rial
        public static readonly Currency YER = new Currency(YER_NAME);

        /// Currency instance: South African Rand
        public static readonly Currency ZAR = new Currency(ZAR_NAME);

        /// Currency instance: Zimbabwe Dollar
        public static readonly Currency ZWL = new Currency(ZWL_NAME);


        private static readonly Dictionary<string, int> CurrencySymbolToDigits = new Dictionary<string, int>()
        {
            {AED_NAME, 2},
            {ALL_NAME, 2},
            {AMD_NAME, 2},
            {ARS_NAME, 2},
            {AUD_NAME, 2},
            {AZN_NAME, 2},
            {BGN_NAME, 2},
            {BHD_NAME, 3},
            {BND_NAME, 2},
            {BOB_NAME, 2},
            {BRL_NAME, 2},
            {BYR_NAME, 0},
            {BZD_NAME, 2},
            {CAD_NAME, 2},
            {CHF_NAME, 2},
            {CLP_NAME, 0},
            {CNY_NAME, 2},
            {COP_NAME, 2},
            {CRC_NAME, 2},
            {CZK_NAME, 2},
            {DKK_NAME, 2},
            {DOP_NAME, 2},
            {DZD_NAME, 2},
            {EEK_NAME, 2},
            {EGP_NAME, 2},
            {ETB_NAME, 2},
            {EUR_NAME, 2},
            {GBP_NAME, 2},
            {GEL_NAME, 2},
            {GTQ_NAME, 2},
            {HKD_NAME, 2},
            {HNL_NAME, 2},
            {HRK_NAME, 2},
            {HUF_NAME, 2},
            {IDR_NAME, 2},
            {ILS_NAME, 2},
            {INR_NAME, 2},
            {IQD_NAME, 3},
            {IRR_NAME, 2},
            {ISK_NAME, 0},
            {JMD_NAME, 2},
            {JOD_NAME, 3},
            {JPY_NAME, 0},
            {KES_NAME, 2},
            {KGS_NAME, 2},
            {KRW_NAME, 0},
            {KWD_NAME, 3},
            {KZT_NAME, 2},
            {LBP_NAME, 2},
            {LTL_NAME, 2},
            {LVL_NAME, 2},
            {LYD_NAME, 3},
            {MAD_NAME, 2},
            {MKD_NAME, 2},
            {MNT_NAME, 2},
            {MOP_NAME, 2},
            {MVR_NAME, 2},
            {MXN_NAME, 2},
            {MYR_NAME, 2},
            {NIO_NAME, 2},
            {NOK_NAME, 2},
            {NZD_NAME, 2},
            {OMR_NAME, 3},
            {PAB_NAME, 2},
            {PEN_NAME, 2},
            {PHP_NAME, 2},
            {PKR_NAME, 2},
            {PLN_NAME, 2},
            {PYG_NAME, 0},
            {QAR_NAME, 2},
            {RON_NAME, 2},
            {RSD_NAME, 2},
            {RUB_NAME, 2},
            {SAR_NAME, 2},
            {SEK_NAME, 2},
            {SGD_NAME, 2},
            {SYP_NAME, 2},
            {THB_NAME, 2},
            {TND_NAME, 3},
            {TRY_NAME, 2},
            {TTD_NAME, 2},
            {TWD_NAME, 2},
            {UAH_NAME, 2},
            {USD_NAME, 2},
            {UYU_NAME, 2},
            {UZS_NAME, 2},
            {VEF_NAME, 2},
            {VND_NAME, 0},
            {YER_NAME, 2},
            {ZAR_NAME, 2},
            {ZWL_NAME, 2}
        };

        private readonly string _currencyName;

        private Currency(string currencyName)
        {
            _currencyName = currencyName;
        }

        public int GetDefaultFractionDigits()
        {
            return CurrencySymbolToDigits[_currencyName];
        }


        public bool Equals(Currency other)
        {
            return _currencyName == other._currencyName;
        }

        public override bool Equals(object obj)
        {
            return obj is Currency other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _currencyName.GetHashCode();
        }

        public override string ToString()
        {
            return _currencyName;
        }
    }
}