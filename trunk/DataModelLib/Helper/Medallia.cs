using System;
using System.Runtime.Serialization;

namespace DataModelLib.Helper
{
    [DataContract]
    public class Medallia
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string MedalliaId { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string PropertyCode { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string RoomNumber { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string Title { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string GuestFirstName { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string GuestLastName { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        public DateTime ChceckInDate { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public DateTime ChceckOutDate { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public string Address1 { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public string Address2 { get; set; }

        [DataMember(Order = 12, EmitDefaultValue = false)]
        public string Address3 { get; set; }

        [DataMember(Order = 13, EmitDefaultValue = false)]
        public string Address4 { get; set; }

        [DataMember(Order = 14, EmitDefaultValue = false)]
        public string AddressType { get; set; }

        [DataMember(Order = 15, EmitDefaultValue = false)]
        public string PostCode { get; set; }

        [DataMember(Order = 16, EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Order = 17, EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Order = 18, EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Order = 19, EmitDefaultValue = false)]
        public string RoomRate { get; set; }

        [DataMember(Order = 20, EmitDefaultValue = false)]
        public string ReservationNo { get; set; }

        [DataMember(Order = 21, EmitDefaultValue = false)]
        public string RoomType { get; set; }

        [DataMember(Order = 22, EmitDefaultValue = false)]
        public string RateCode { get; set; }

        [DataMember(Order = 23, EmitDefaultValue = false)]
        public string RateValue { get; set; }

        [DataMember(Order = 24, EmitDefaultValue = false)]
        public string LoyalProgramNo { get; set; }

        [DataMember(Order = 25, EmitDefaultValue = false)]
        public string LoyalProgramStatus { get; set; }

        [DataMember(Order = 26, EmitDefaultValue = false)]
        public string CustomerType { get; set; }

        [DataMember(Order = 27, EmitDefaultValue = false)]
        public string MarketSegmentCode { get; set; }

        [DataMember(Order = 28, EmitDefaultValue = false)]
        public string SourceCode { get; set; }

        [DataMember(Order = 29, EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        [DataMember(Order = 30, EmitDefaultValue = false)]
        public string TotalRoomRev { get; set; }

        [DataMember(Order = 31, EmitDefaultValue = false)]
        public string TotalFbRev { get; set; }

        [DataMember(Order = 32, EmitDefaultValue = false)]
        public string TotalExtraRev { get; set; }

        [DataMember(Order = 33, EmitDefaultValue = false)]
        public string TotalRev { get; set; }
    }
}