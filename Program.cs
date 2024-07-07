// Avaga task from video
Main();

void Main()
{
    List<int>? fileData = GetDataOfFile( "17.txt" );

    if( fileData == null )
    {
        Console.WriteLine( "File loaded incorrect" );
        return;
    }

    int maxPow = GetMaxPow( fileData );

    List<int> result = new List<int>();

    for( int current = 0, next = 1; current < fileData.Count - 1; current++, next++ )
    {
        bool isValidPair = IsValidPair( Math.Abs( fileData[current] ), Math.Abs( fileData[next] ) );
        int powOfPair = current * current + next * next;

        if( isValidPair && powOfPair > maxPow )
        {
            result.Add( powOfPair );
        }
    }

    Console.WriteLine( $"{result.Count} : {result.Max()}" );
}

bool IsValidPair( int current, int next ) => ( current % 10 == 3 ) != ( next % 10 == 3 );

int GetMaxPow( List<int> data ) => (int) Math.Pow( data.Where( x => x % 10 == 3 ).Max(), 2 );

List<int>? GetDataOfFile( string fileName ) => !File.Exists( fileName ) ? null : File.ReadAllLines( fileName ).Select( x => Convert.ToInt32( x ) ).ToList();
