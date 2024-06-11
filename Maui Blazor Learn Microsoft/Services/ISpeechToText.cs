using System.Globalization;
using CommunityToolkit.Maui.Media;

namespace Maui_Blazor_Learn_Microsoft;

public interface ISpeechToText
{
	event Action<string> RecognitionResultUpdated;
	Task RecognizeSpeechAsync(CancellationToken cancellationToken);
}

public class SpeechToTextService : ISpeechToText
{
	public event Action<string> RecognitionResultUpdated;

	public SpeechToTextService()
	{
        SpeechToText.Default.RecognitionResultUpdated += (sender, args) => RecognitionResultUpdated?.Invoke(args.RecognitionResult);
	}

	public async Task RecognizeSpeechAsync(CancellationToken cancellationToken)
	{
		var isGranted = await SpeechToText.RequestPermissions(cancellationToken);
		if (!isGranted)
		{
			throw new Exception("Permission not granted");
		}

		await SpeechToText.ListenAsync(
			CultureInfo.CurrentCulture,
			new Progress<string>(), cancellationToken);
	}
}
