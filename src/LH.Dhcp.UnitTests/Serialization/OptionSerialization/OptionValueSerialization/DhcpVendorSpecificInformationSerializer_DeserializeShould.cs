namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpVendorSpecificInformationSerializer_DeserializeShould
    {
        public void Dummy()
        {
        }

        /*
         * Single value
         * ====================
         *  String              => Any
         *  ByteArray           => Any
         *  Byte                => 1
         *  UnsignedInt32       => 4
         *  UnsignedInt16       => 2
         *  SignedInt32         => 4
         *  SignedInt16         => 2
         *  Bool                => 1
         *  IPAddress           => 4
         *  Array<all the above>
         */
    }

    /*
     * VendorSpecificInformationOption
     *  GetSingleValueReader()
     *  GetMultiValueReader()
     *      ReadIPAddress()....
     *      ReadIPAddressArray()
     *      ReadBoolOption()  => VendorSpecificOption<bool> { OptionId = int, Value = bool }
     */
}