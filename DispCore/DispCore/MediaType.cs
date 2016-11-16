using System;

namespace DispCore
{
	public enum MediaType
	{
		None,
		Audio = 2,
		Video = 4,
		Msrp = 8,
		T140 = 16,
		BFCP = 128,
		Audiobfcp = 384,
		Videobfcp = 640,
		SMS = 262144,
		ShortMessage = 524288,
		Chat = 1048576,
		FileTransfer = 2097152,
		Messaging = 1835008,
		AudioT140 = 18,
		AudioVideo = 6,
		All = -1
	}
}
