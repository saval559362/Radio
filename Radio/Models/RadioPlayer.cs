using System;
using Un4seen.Bass;
namespace Radio.Models
{
    public static class RadioPlayer
    {   
        /// <summary>
        /// Частота дискретизации
        /// </summary>
        private static int _hz = 44100;
        /// <summary>
        /// Состояние инициализации
        /// </summary>
        public static bool InitDefaultDevice;
        /// <summary>
        /// Канал
        /// </summary>
        public static int Stream;
        /// <summary>
        /// Громкость
        /// </summary>
        public static int Volume = 100;
        /// <summary>
        /// Инициализация Bass.dll
        /// </summary>
        /// <param name="hz"></param>
        /// <returns></returns>
        private static bool InitBass(int hz)
        {
            if (!InitDefaultDevice)
                InitDefaultDevice = Bass.BASS_Init(-1, hz, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            return InitDefaultDevice;
        }
        /// <summary>
        /// Вопроизведение
        /// </summary>
        /// <param name="potokName"></param>
        /// <param name="vol"></param>
        public static void Play(string potokName, int vol)
        {
            Stop();

            if (InitBass(_hz))
            {
                Stream = Bass.BASS_StreamCreateURL(potokName, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
                if (Stream != 0)
                {
                    Volume = vol;
                    Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, Volume / 100F);
                    Bass.BASS_ChannelPlay(Stream, false);
                }
            }
        }

        /// <summary>
        /// Стоп
        /// </summary>
        public static void Stop()
        {
            Bass.BASS_ChannelStop(Stream);
            Bass.BASS_StreamFree(Stream);
        }

        /// <summary>
        /// Получение длительности канала в секундах
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetTimeOfStream(int stream)
        {
            long TimeBytes = Bass.BASS_ChannelGetLength(stream);
            double Time = Bass.BASS_ChannelSeconds2Bytes(stream, TimeBytes);
            return (int)Time;
        }

        /// <summary>
        /// Установка громкости
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="vol"></param>
        public static void SetVolumeToStream(int stream, int vol)
        {
            Volume = vol;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, Volume / 100F);
        }
    }
}