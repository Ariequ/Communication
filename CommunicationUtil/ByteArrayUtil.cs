public class ByteArrayUtil {
	/**
	 * 转换int为byte数组
	 * 
	 * @param x
	 */
	public static byte[] intToBytes(int x) {
		byte[] bytes = new byte[4];
		bytes[0] = (byte) (x >> 24);
		bytes[1] = (byte) (x >> 16);
		bytes[2] = (byte) (x >> 8);
		bytes[3] = (byte) (x >> 0);
		return bytes;
	}

	public static byte[] shortToByteArray(short s) {  
		byte[] targets = new byte[2];  
//		for (int i = 0; i < 2; i++) {  
//			int offset = (targets.Length - 1 - i) * 8;  
//			targets[i] = (byte) ((s >>> offset) & 0xff);  
//		}  
//		return targets; 

		targets[0] = (byte)(s >> 8);
		targets[1] = (byte)(s & 255);

		return targets;
	}  


	
	/**
	 * 通过byte数组取到int
	 * 
	 * @param bytes
	 * @return
	 */
	public static int bytesToInt(byte[] bytes) {
		return (int) ((((bytes[0] & 0xFF) << 24) | ((bytes[1] & 0xFF) << 16)
		               | ((bytes[2] & 0xFF) << 8) | ((bytes[3] & 0xFF) << 0)));
	}
}
