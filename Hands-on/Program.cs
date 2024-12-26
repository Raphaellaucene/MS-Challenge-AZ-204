using System.Text;

if (Systen.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
{
    stringBuilder sb = new stringBuilder();
    sb.AppendLine("Current IP Address: ");
    Console.WriteLine("Current IP Address: ");
    string hostName = System.Net.Dns.GetHostName();
    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(hostName);

    foreach (System.Net.IPAddress ip in host.AddressList)
    {
        sb.AppendLine($"\t{address}");
    }
    Console.WriteLine(sb.ToString());
}
else
{
    Console.WriteLine("Network is not available");
}