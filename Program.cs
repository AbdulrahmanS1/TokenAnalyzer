using System;
using System.Collections;

namespace TokenAnalyzer
{
    class Analyzer
    {
        static void analyzeTweet(string tweet)
        {
            ArrayList mentions = new ArrayList();
            ArrayList hashtags = new ArrayList();
            int i = 0;
            while (i < tweet.Length)
            {
                if (
                    (i == 0 && tweet[i] == '@') ||
                    (tweet[i] == '@' && Char.IsWhiteSpace(tweet[i - 1]))
                    )
                {
                    string username = "";
                    if (i == 0)
                    {
                        username += tweet[i];
                    }
                    else
                    {
                        username += tweet[i];
                    }

                    int maxLen = 15;
                    while (
                        (i + 1) < tweet.Length && maxLen > 0 &&
                        (Char.IsLetterOrDigit(tweet[i + 1]) || tweet[i + 1] == '_')
                        )
                    {
                        username += tweet[++i];
                        --maxLen;
                    }

                    if (username.Length > 1)
                        mentions.Add(username);
                }

                if (
                    (i == 0 && tweet[i] == '#') ||
                    (tweet[i] == '#' && Char.IsWhiteSpace(tweet[i - 1]))
                    )
                {
                    string hashtag = "";
                    if (i == 0)
                    {
                        hashtag += tweet[i];
                    }
                    else
                    {
                        hashtag += tweet[i];
                    }

                    while (
                        (i + 1) < tweet.Length &&
                        (Char.IsLetterOrDigit(tweet[i + 1]) || tweet[i + 1] == '_')
                        )
                    {
                        hashtag += tweet[++i];

                    }

                    if (hashtag.Length > 1)
                        hashtags.Add(hashtag);
                }

                ++i;
            }

            Console.WriteLine($"The tweet contains {mentions.Count} mention(s):");
            foreach (var handle in mentions)
            {
                Console.WriteLine(handle);
            }

            Console.WriteLine($"\nThe tweet contains {hashtags.Count} hashtag(s):");
            foreach (var hashtag in hashtags)
            {
                Console.WriteLine(hashtag);
            }
        }

        static void Main(string[] args)
        {
            // analyzeTweet("#المنيع_في_ليوان_المديفر @may___od368_ Replying to #المنيع_وان_المديفر@___mayod368 يلا اهمشي@mayod368في النهاية تعاد @_mayo_d368_");
            analyzeTweet("#BREAKING: Custodian of the Two Holy Mosques King Salman receives a phone call from the Turkish president Recep Tayyip Erdogan, exchange #Ramadan greeting @ #");

        }
    }
    }

