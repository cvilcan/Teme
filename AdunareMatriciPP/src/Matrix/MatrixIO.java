package Matrix;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class MatrixIO
{
	public int ReadInt(String message)
	{
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		int number = 0;
		
		System.out.println(message);
		try
		{
            number = Integer.parseInt(br.readLine());
        }catch(Exception nfe)
		{
            System.err.println("Invalid Format!");
		}
		return number;
	}
}
