using org.doubango.tinyWRAP;
using System;
using System.Runtime.InteropServices;

namespace DispCore.Models
{
	public class MyXcapMessage
	{
		private readonly short code;

		private readonly string phrase;

		private readonly string contentType;

		private readonly byte[] content;

		internal short Code
		{
			get
			{
				return this.code;
			}
		}

		internal string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		internal string ContentType
		{
			get
			{
				return this.contentType;
			}
		}

		internal byte[] Content
		{
			get
			{
				return this.content;
			}
		}

		internal MyXcapMessage(XcapMessage message)
		{
			if (message == null)
			{
				this.code = -1;
				this.phrase = string.Empty;
				this.contentType = string.Empty;
			}
			else
			{
				this.code = message.getCode();
				this.phrase = message.getPhrase();
				this.contentType = message.getXcapHeaderValue("Content-Type");
				uint clen = message.getXcapContentLength();
				if (clen > 0u)
				{
					this.content = new byte[clen];
					System.IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)clen);
					message.getXcapContent(ptr, clen);
					System.Runtime.InteropServices.Marshal.Copy(ptr, this.content, 0, this.content.Length);
					System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
				}
				else
				{
					this.content = null;
				}
			}
		}
	}
}
