using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ImGuiNET
{
    public static unsafe partial class ImGui
    {
        public static bool BeginPopupModal(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> name,
#else
            string name,
#endif
            ImGuiWindowFlags flags)
        {
            byte* native_name;
            int name_byteCount = 0;
            if (name != null)
            {
                name_byteCount = Encoding.UTF8.GetByteCount(name);
                if (name_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_name = Util.Allocate(name_byteCount + 1);
                }
                else
                {
                    byte* native_name_stackBytes = stackalloc byte[name_byteCount + 1];
                    native_name = native_name_stackBytes;
                }
                int native_name_offset = Util.GetUtf8(name, native_name, name_byteCount);
                native_name[native_name_offset] = 0;
            }
            else { native_name = null; }
            byte* p_open = null;
            byte ret = ImGuiNative.igBeginPopupModal(native_name, p_open, flags);
            if (name_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_name);
            }
            return ret != 0;
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool Begin(ReadOnlySpan<char> name, ImGuiWindowFlags flags)
#else
        public static bool Begin(string name, ImGuiWindowFlags flags)
#endif
        {
            int utf8NameByteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8NameBytes;
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                utf8NameBytes = Util.Allocate(utf8NameByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8NameByteCount + 1];
                utf8NameBytes = stackPtr;
            }
            Util.GetUtf8(name, utf8NameBytes, utf8NameByteCount);

            byte* p_open = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, p_open, flags);

            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }

            return ret != 0;
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool MenuItem(ReadOnlySpan<char> label, bool enabled)
#else
        public static bool MenuItem(string label, bool enabled)
#endif
        {
            return MenuItem(label, string.Empty, false, enabled);
        }



        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref sbyte data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            sbyte? step = null,
            sbyte? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.S8, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref byte data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            byte? step = null,
            byte? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.U8, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref short data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            short? step = null,
            short? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.S16, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref ushort data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            ushort? step = null,
            ushort? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.U16, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref int data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            int? step = null,
            int? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.S32, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref uint data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            uint? step = null,
            uint? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.U32, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref long data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            long? step = null,
            long? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.S64, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref ulong data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            ulong? step = null,
            ulong? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.U64, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref float data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            float? step = null,
            float? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.Float, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

        public static bool InputScalar(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref double data,
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> format = default,
#else
            string format = default,
#endif
            double? step = null,
            double? stepFast = null,
            ImGuiInputTextFlags flags = ImGuiInputTextFlags.None)
        {
            IntPtr dataPtr;
            IntPtr stepPtr = IntPtr.Zero;
            IntPtr stepFastPtr = IntPtr.Zero;

            fixed (void* fixedData = &data)
            {
                dataPtr = new IntPtr(fixedData);

                var stepValue = step ?? default;
                if (step.HasValue)
                {
                    stepPtr = new IntPtr(&stepValue);
                }

                var stepFastValue = stepFast.HasValue ? stepFast.Value : default;
                if (stepFast.HasValue)
                {
                    stepFastPtr = new IntPtr(&stepFastValue);
                }

                return InputScalar(label, ImGuiDataType.Double, dataPtr, stepPtr, stepFastPtr, format, flags);
            }
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool InputScalar(ReadOnlySpan<char> label, ImGuiDataType data_type, IntPtr p_data)
#else
        public static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format)
#endif
            => InputScalar(label, data_type, p_data, IntPtr.Zero, IntPtr.Zero, null, ImGuiInputTextFlags.None);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool InputScalar(ReadOnlySpan<char> label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step)
#else
        public static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format)
#endif
            => InputScalar(label, data_type, p_data, p_step, IntPtr.Zero, null, ImGuiInputTextFlags.None);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool InputScalar(ReadOnlySpan<char> label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast)
#else
        public static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format)
#endif
            => InputScalar(label, data_type, p_data, p_step, p_step_fast, null, ImGuiInputTextFlags.None);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool InputScalar(ReadOnlySpan<char> label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, ReadOnlySpan<char> format)
#else
        public static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format)
#endif
            => InputScalar(label, data_type, p_data, p_step, p_step_fast, format, ImGuiInputTextFlags.None);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static bool InputScalar(ReadOnlySpan<char> label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, ReadOnlySpan<char> format, ImGuiInputTextFlags flags)
#else
        public static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format, ImGuiInputTextFlags flags)
#endif
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }
                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else { native_label = null; }
            void* native_p_data = (void*)p_data.ToPointer();
            void* native_p_step = (void*)p_step.ToPointer();
            void* native_p_step_fast = (void*)p_step_fast.ToPointer();
            byte* native_format;
            int format_byteCount = 0;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            if (!format.IsEmpty)
#else
            if (!string.IsNullOrEmpty(format))
#endif
            {
                format_byteCount = Encoding.UTF8.GetByteCount(format);
                if (format_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_format = Util.Allocate(format_byteCount + 1);
                }
                else
                {
                    byte* native_format_stackBytes = stackalloc byte[format_byteCount + 1];
                    native_format = native_format_stackBytes;
                }
                int native_format_offset = Util.GetUtf8(format, native_format, format_byteCount);
                native_format[native_format_offset] = 0;
            }
            else { native_format = null; }
            byte ret = ImGuiNative.igInputScalar(native_label, data_type, native_p_data, native_p_step, native_p_step_fast, native_format, flags);
            if (label_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_label);
            }
            if (format_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_format);
            }
            return ret != 0;
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            byte[] buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret;
            fixed (byte* bufPtr = buf)
            {
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, buf_size, flags, callback, user_data.ToPointer()) != 0;
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength) => InputText(label, ref input, maxLength, 0, null, IntPtr.Zero);

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        public static bool InputTextMultiline(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            Vector2 size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);

        public static bool InputTextMultiline(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);

        public static bool InputTextMultiline(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);

        public static bool InputTextMultiline(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                size,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        public static bool InputTextWithHint(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
#else
            string label,
            string hint,
#endif
            ref string input,
            uint maxLength) => InputTextWithHint(label, hint, ref input, maxLength, 0, null, IntPtr.Zero);

        public static bool InputTextWithHint(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
#else
            string label,
            string hint,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);

        public static bool InputTextWithHint(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
#else
            string label,
            string hint,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);

        public static bool InputTextWithHint(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
#else
            string label,
            string hint,
#endif
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8HintByteCount = Encoding.UTF8.GetByteCount(hint);
            byte* utf8HintBytes;
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                utf8HintBytes = Util.Allocate(utf8HintByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8HintByteCount + 1];
                utf8HintBytes = stackPtr;
            }
            Util.GetUtf8(hint, utf8HintBytes, utf8HintByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8HintBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static Vector2 CalcTextSize(ReadOnlySpan<char> text)
            => CalcTextSizeImpl(text);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start)
            => CalcTextSizeImpl(text, start);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);
#else
        public static Vector2 CalcTextSize(string text)
            => CalcTextSizeImpl(text);

        public static Vector2 CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);

        public static Vector2 CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);
#endif

        private static Vector2 CalcTextSizeImpl(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> text,
#else
            string text,
#endif
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            Vector2 ret;
            byte* nativeTextStart = null;
            byte* nativeTextEnd = null;
            int textByteCount = 0;
            if (text != null)
            {

                int textToCopyLen = length.HasValue ? length.Value : text.Length;
                textByteCount = Util.CalcSizeInUtf8(text, start, textToCopyLen);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTextStart = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeTextStart = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, start, textToCopyLen, nativeTextStart, textByteCount);
                nativeTextStart[nativeTextOffset] = 0;
                nativeTextEnd = nativeTextStart + nativeTextOffset;
            }

            ImGuiNative.igCalcTextSize(&ret, nativeTextStart, nativeTextEnd, *((byte*)(&hideTextAfterDoubleHash)), wrapWidth);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTextStart);
            }

            return ret;
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            IntPtr buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        public static bool InputText(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
            ReadOnlySpan<char> label,
#else
            string label,
#endif
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*)buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) != 0;

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }
    }
}
