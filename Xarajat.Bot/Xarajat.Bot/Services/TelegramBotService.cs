using Microsoft.Extensions.Options;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Xarajat.Bot.Options;

namespace Xarajat.Bot.Services;

public class TelegramBotService
{
	private readonly TelegramBotClient _bot;
	private CancellationToken cancellationToken;

	public TelegramBotService(IOptions<XarajatBotOptions> options)
	{
		_bot = new TelegramBotClient(options.Value.BotToken);
	}

    public async Task SendMessage(long chatId, string message, IReplyMarkup? reply = null)
    {
        await _bot.SendTextMessageAsync(chatId, message, replyMarkup: reply);
    }

    public async Task SendMessage(long chatId, string message, Stream image, IReplyMarkup? reply = null)
    {
        await _bot.SendPhotoAsync(chatId, new InputOnlineFile(image), message, replyMarkup: reply);
    }

    public async Task EditMessageButtons(long chatId, int messageId, InlineKeyboardMarkup reply)
    {
        await _bot.EditMessageReplyMarkupAsync(chatId, messageId, replyMarkup: reply);
    }

    public ReplyKeyboardMarkup GetKeyboard(List<string> buttonsText)
    {
        return new ReplyKeyboardMarkup(buttonsText.Select(text =>
            new KeyboardButton[] { new(text) }))
        { ResizeKeyboard = true };
    }

    public InlineKeyboardMarkup GetInlineKeyboard(List<string> buttonsText)
    {
        return new InlineKeyboardMarkup(buttonsText.Select(text => new[]
        {
            InlineKeyboardButton.WithCallbackData(text: text, callbackData: text)
        }));
    }
}
