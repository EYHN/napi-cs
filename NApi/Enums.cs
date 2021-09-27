using System;

namespace NApi
{
    public enum napi_property_attributes
    {
        napi_default = 0,
        napi_writable = 1,
        napi_enumerable = 2,
        napi_configurable = 4,
        napi_static = 1024,
        napi_default_method = 5,
        napi_default_jsproperty = 7
    }

    public enum napi_valuetype
    {
        napi_undefined = 0,
        napi_null = 1,
        napi_boolean = 2,
        napi_number = 3,
        napi_string = 4,
        napi_symbol = 5,
        napi_object = 6,
        napi_function = 7,
        napi_external = 8,
        napi_bigint = 9
    }

    public enum napi_typedarray_type
    {
        napi_int8_array = 0,
        napi_uint8_array = 1,
        napi_uint8_clamped_array = 2,
        napi_int16_array = 3,
        napi_uint16_array = 4,
        napi_int32_array = 5,
        napi_uint32_array = 6,
        napi_float32_array = 7,
        napi_float64_array = 8,
        napi_bigint64_array = 9,
        napi_biguint64_array = 10
    }

    public enum napi_status
    {
        napi_ok = 0,
        napi_invalid_arg = 1,
        napi_object_expected = 2,
        napi_string_expected = 3,
        napi_name_expected = 4,
        napi_function_expected = 5,
        napi_number_expected = 6,
        napi_boolean_expected = 7,
        napi_array_expected = 8,
        napi_generic_failure = 9,
        napi_pending_exception = 10,
        napi_cancelled = 11,
        napi_escape_called_twice = 12,
        napi_handle_scope_mismatch = 13,
        napi_callback_scope_mismatch = 14,
        napi_queue_full = 15,
        napi_closing = 16,
        napi_bigint_expected = 17,
        napi_date_expected = 18,
        napi_arraybuffer_expected = 19,
        napi_detachable_arraybuffer_expected = 20,
        napi_would_deadlock = 21
    }

    public enum napi_key_collection_mode
    {
        napi_key_include_prototypes = 0,
        napi_key_own_only = 1
    }

    [Flags]
    public enum napi_key_filter
    {
        napi_key_all_properties = 0,
        napi_key_writable = 1,
        napi_key_enumerable = 2,
        napi_key_configurable = 4,
        napi_key_skip_strings = 8,
        napi_key_skip_symbols = 16
    }

    public enum napi_key_conversion
    {
        napi_key_keep_numbers = 0,
        napi_key_numbers_to_strings = 1
    }
}