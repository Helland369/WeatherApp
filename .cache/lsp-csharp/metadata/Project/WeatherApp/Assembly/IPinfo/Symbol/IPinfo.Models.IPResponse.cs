#region Assembly IPinfo, Version=3.0.1.0, Culture=neutral, PublicKeyToken=4232cd40b37f70d5
// IPinfo.dll
#endregion

using System.Text.Json.Serialization;

namespace IPinfo.Models
{
    public class IPResponse
    {
        public IPResponse();

        [JsonInclude]
        public Privacy Privacy { get; }
        [JsonInclude]
        public Carrier Carrier { get; }
        [JsonInclude]
        public Company Company { get; }
        [JsonInclude]
        public ASN Asn { get; }
        [JsonInclude]
        public string IP { get; }
        [JsonInclude]
        public string Timezone { get; }
        [JsonInclude]
        public string Region { get; }
        [JsonInclude]
        public string Postal { get; }
        [JsonInclude]
        public string Org { get; }
        public string Longitude { get; }
        public string Latitude { get; }
        [JsonInclude]
        public string Loc { get; }
        [JsonInclude]
        public string Hostname { get; }
        public Continent Continent { get; }
        public CountryCurrency CountryCurrency { get; }
        public string CountryFlagURL { get; }
        public CountryFlag CountryFlag { get; }
        public bool IsEU { get; }
        public string CountryName { get; }
        [JsonInclude]
        public string Country { get; }
        [JsonInclude]
        public string City { get; }
        [JsonInclude]
        public bool Bogon { get; }
        [JsonInclude]
        public bool Anycast { get; }
        [JsonInclude]
        public Abuse Abuse { get; }
        [JsonInclude]
        public DomainsList Domains { get; }
    }
}