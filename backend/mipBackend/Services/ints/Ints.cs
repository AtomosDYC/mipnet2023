namespace mipBackend.Services.ints
{
    public static class Ints 
    {

        public static int? ParseNullableInt(this object value)
        {
            if (value == null) 
            {
                return null;
            }
            else
            {
                try
                {
                    return int.Parse(value.ToString());
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
