using EVE.SDK;

namespace EVE.Engine.Providers
{
    public class ProgramProvider
    {
        private string _path;

        public ProgramProvider(string path)
        {
            _path = path;
        }

        public EveProgram Load()
        {
            return new EveProgram()
            {
                Name = GetProgramName(),
                Data = GetProgramData(),
                Size = GetProgramSize()
            };
        }

        private string GetProgramName()
        {
            // TODO: Read firt 32 bytes of file and extract name
            throw new NotImplementedException();
        }

        private int GetProgramSize()
        {
            // TODO: Count bytes in file, not including header
            throw new NotImplementedException();
        }

        private byte[] GetProgramData()
        {
            // TODO: Read bytes from file, not including header, and disregard commas, spaces, and newlines.
            // Example: 0x01, 0x05, 0x01, 0x17, 0x03, 0x01, 0x08, 0x00, 0x0D -> reads into byte array { 0x01, 0x05, 0x01, 0x17, 0x03, 0x01, 0x08, 0x00, 0x0D }
            throw new NotImplementedException();
        }
    }
}
