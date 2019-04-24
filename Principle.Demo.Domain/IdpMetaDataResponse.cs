using System.Runtime.Serialization;

namespace Principle.Demo.Domain
{
    [DataContract]
    public class IdpMetaDataResponse
    {
        [DataMember(Name = "auth_id")]
        public string AuthId { get; set; }
        [DataMember(Name = "auth_name")]
        public string AuthName { get; set; }
        [DataMember(Name = "tenant_id")]
        public string TenantId { get; set; }
        [DataMember(Name = "protocol")]
        public int Protocol { get; set; }
        [DataMember(Name = "idp_issuer")]
        public string IdPIssuer { get; set; }
        [DataMember(Name = "idp_sso_url")]
        public string IdPSsoUrl { get; set; }
        [DataMember(Name = "idp_certificate")]
        public string IdPCertificate { get; set; }
        [DataMember(Name = "sp_issuer")]
        public string SpIssuer { get; set; }
        [DataMember(Name = "sp_sso_url")]
        public string SpSsoUrl { get; set; }
        [DataMember(Name = "sp_certificate")]
        public string SpCertificate { get; set; }
        [DataMember(Name = "sp_private_key")]
        public string SpPrivateKey { get; set; }
        [DataMember(Name = "signature_algorithm")]
        public string SignatureAlgorithm { get; set; }
        [DataMember(Name = "map_attribute")]
        public int? MapAttribute { get; set; }
        [DataMember(Name = "status")]
        public int? Status { get; set; }
    }
}

