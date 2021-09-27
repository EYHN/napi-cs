using System;

namespace NApi
{
    public interface INApiProvider
    {
        public IJsNativeApiProvider JsNativeApi { get; }
        
        public unsafe interface IJsNativeApiProvider
        {
            delegate napi_status napi_get_last_error_info_delegate(IntPtr env, IntPtr result);

            public napi_get_last_error_info_delegate napi_get_last_error_info { get; }

            delegate napi_status napi_get_undefined_delegate(IntPtr env, IntPtr result);

            public napi_get_undefined_delegate napi_get_undefined { get; }

            delegate napi_status napi_get_null_delegate(IntPtr env, IntPtr result);

            public napi_get_null_delegate napi_get_null { get; }

            delegate napi_status napi_get_global_delegate(IntPtr env, IntPtr result);

            public napi_get_global_delegate napi_get_global { get; }

            delegate napi_status napi_get_boolean_delegate(IntPtr env, bool value, IntPtr result);

            public napi_get_boolean_delegate napi_get_boolean { get; }

            delegate napi_status napi_create_object_delegate(IntPtr env, IntPtr result);

            public napi_create_object_delegate napi_create_object { get; }

            delegate napi_status napi_create_array_delegate(IntPtr env, IntPtr result);

            public napi_create_array_delegate napi_create_array { get; }

            delegate napi_status napi_create_array_with_length_delegate(IntPtr env, ulong length, IntPtr result);

            public napi_create_array_with_length_delegate napi_create_array_with_length { get; }

            delegate napi_status napi_create_double_delegate(IntPtr env, double value, IntPtr result);

            public napi_create_double_delegate napi_create_double { get; }

            delegate napi_status napi_create_int32_delegate(IntPtr env, int value, IntPtr result);

            public napi_create_int32_delegate napi_create_int32 { get; }

            delegate napi_status napi_create_uint32_delegate(IntPtr env, uint value, IntPtr result);

            public napi_create_uint32_delegate napi_create_uint32 { get; }

            delegate napi_status napi_create_int64_delegate(IntPtr env, long value, IntPtr result);

            public napi_create_int64_delegate napi_create_int64 { get; }

            delegate napi_status napi_create_string_latin1_delegate(IntPtr env, string str, ulong length, IntPtr result);

            public napi_create_string_latin1_delegate napi_create_string_latin1 { get; }

            delegate napi_status napi_create_string_utf8_delegate(IntPtr env, string str, ulong length, IntPtr result);

            public napi_create_string_utf8_delegate napi_create_string_utf8 { get; }

            delegate napi_status napi_create_string_utf16_delegate(IntPtr env, string str, ulong length, IntPtr result);

            public napi_create_string_utf16_delegate napi_create_string_utf16 { get; }

            delegate napi_status napi_create_symbol_delegate(IntPtr env, IntPtr description, IntPtr result);

            public napi_create_symbol_delegate napi_create_symbol { get; }

            delegate napi_status napi_create_function_delegate(IntPtr env, string utf8name, ulong length, IntPtr cb, IntPtr data, IntPtr result);

            public napi_create_function_delegate napi_create_function { get; }

            delegate napi_status napi_create_error_delegate(IntPtr env, IntPtr code, IntPtr msg, IntPtr result);

            public napi_create_error_delegate napi_create_error { get; }

            delegate napi_status napi_create_type_error_delegate(IntPtr env, IntPtr code, IntPtr msg, IntPtr result);

            public napi_create_type_error_delegate napi_create_type_error { get; }

            delegate napi_status napi_create_range_error_delegate(IntPtr env, IntPtr code, IntPtr msg, IntPtr result);

            public napi_create_range_error_delegate napi_create_range_error { get; }

            delegate napi_status napi_typeof_delegate(IntPtr env, IntPtr value, napi_valuetype* result);

            public napi_typeof_delegate napi_typeof { get; }

            delegate napi_status napi_get_value_double_delegate(IntPtr env, IntPtr value, double* result);

            public napi_get_value_double_delegate napi_get_value_double { get; }

            delegate napi_status napi_get_value_int32_delegate(IntPtr env, IntPtr value, int* result);

            public napi_get_value_int32_delegate napi_get_value_int32 { get; }

            delegate napi_status napi_get_value_uint32_delegate(IntPtr env, IntPtr value, uint* result);

            public napi_get_value_uint32_delegate napi_get_value_uint32 { get; }

            delegate napi_status napi_get_value_int64_delegate(IntPtr env, IntPtr value, long* result);

            public napi_get_value_int64_delegate napi_get_value_int64 { get; }

            delegate napi_status napi_get_value_bool_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_get_value_bool_delegate napi_get_value_bool { get; }

            delegate napi_status napi_get_value_string_latin1_delegate(IntPtr env, IntPtr value, sbyte* buf, ulong bufsize, ulong* result);

            public napi_get_value_string_latin1_delegate napi_get_value_string_latin1 { get; }

            delegate napi_status napi_get_value_string_utf8_delegate(IntPtr env, IntPtr value, sbyte* buf, ulong bufsize, ulong* result);

            public napi_get_value_string_utf8_delegate napi_get_value_string_utf8 { get; }

            delegate napi_status napi_get_value_string_utf16_delegate(IntPtr env, IntPtr value, char* buf, ulong bufsize, ulong* result);

            public napi_get_value_string_utf16_delegate napi_get_value_string_utf16 { get; }

            delegate napi_status napi_coerce_to_bool_delegate(IntPtr env, IntPtr value, IntPtr result);

            public napi_coerce_to_bool_delegate napi_coerce_to_bool { get; }

            delegate napi_status napi_coerce_to_number_delegate(IntPtr env, IntPtr value, IntPtr result);

            public napi_coerce_to_number_delegate napi_coerce_to_number { get; }

            delegate napi_status napi_coerce_to_object_delegate(IntPtr env, IntPtr value, IntPtr result);

            public napi_coerce_to_object_delegate napi_coerce_to_object { get; }

            delegate napi_status napi_coerce_to_string_delegate(IntPtr env, IntPtr value, IntPtr result);

            public napi_coerce_to_string_delegate napi_coerce_to_string { get; }

            delegate napi_status napi_get_prototype_delegate(IntPtr env, IntPtr @object, IntPtr result);

            public napi_get_prototype_delegate napi_get_prototype { get; }

            delegate napi_status napi_get_property_names_delegate(IntPtr env, IntPtr @object, IntPtr result);

            public napi_get_property_names_delegate napi_get_property_names { get; }

            delegate napi_status napi_set_property_delegate(IntPtr env, IntPtr @object, IntPtr key, IntPtr value);

            public napi_set_property_delegate napi_set_property { get; }

            delegate napi_status napi_has_property_delegate(IntPtr env, IntPtr @object, IntPtr key, bool* result);

            public napi_has_property_delegate napi_has_property { get; }

            delegate napi_status napi_get_property_delegate(IntPtr env, IntPtr @object, IntPtr key, IntPtr result);

            public napi_get_property_delegate napi_get_property { get; }

            delegate napi_status napi_delete_property_delegate(IntPtr env, IntPtr @object, IntPtr key, bool* result);

            public napi_delete_property_delegate napi_delete_property { get; }

            delegate napi_status napi_has_own_property_delegate(IntPtr env, IntPtr @object, IntPtr key, bool* result);

            public napi_has_own_property_delegate napi_has_own_property { get; }

            delegate napi_status napi_set_named_property_delegate(IntPtr env, IntPtr @object, string utf8name, IntPtr value);

            public napi_set_named_property_delegate napi_set_named_property { get; }

            delegate napi_status napi_has_named_property_delegate(IntPtr env, IntPtr @object, string utf8name, bool* result);

            public napi_has_named_property_delegate napi_has_named_property { get; }

            delegate napi_status napi_get_named_property_delegate(IntPtr env, IntPtr @object, string utf8name, IntPtr result);

            public napi_get_named_property_delegate napi_get_named_property { get; }

            delegate napi_status napi_set_element_delegate(IntPtr env, IntPtr @object, uint index, IntPtr value);

            public napi_set_element_delegate napi_set_element { get; }

            delegate napi_status napi_has_element_delegate(IntPtr env, IntPtr @object, uint index, bool* result);

            public napi_has_element_delegate napi_has_element { get; }

            delegate napi_status napi_get_element_delegate(IntPtr env, IntPtr @object, uint index, IntPtr result);

            public napi_get_element_delegate napi_get_element { get; }

            delegate napi_status napi_delete_element_delegate(IntPtr env, IntPtr @object, uint index, bool* result);

            public napi_delete_element_delegate napi_delete_element { get; }

            delegate napi_status napi_define_properties_delegate(IntPtr env, IntPtr @object, ulong property_count, IntPtr properties);

            public napi_define_properties_delegate napi_define_properties { get; }

            delegate napi_status napi_is_array_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_array_delegate napi_is_array { get; }

            delegate napi_status napi_get_array_length_delegate(IntPtr env, IntPtr value, uint* result);

            public napi_get_array_length_delegate napi_get_array_length { get; }

            delegate napi_status napi_strict_equals_delegate(IntPtr env, IntPtr lhs, IntPtr rhs, bool* result);

            public napi_strict_equals_delegate napi_strict_equals { get; }

            delegate napi_status napi_call_function_delegate(IntPtr env, IntPtr recv, IntPtr func, ulong argc, IntPtr argv, IntPtr result);

            public napi_call_function_delegate napi_call_function { get; }

            delegate napi_status napi_new_instance_delegate(IntPtr env, IntPtr constructor, ulong argc, IntPtr argv, IntPtr result);

            public napi_new_instance_delegate napi_new_instance { get; }

            delegate napi_status napi_instanceof_delegate(IntPtr env, IntPtr @object, IntPtr constructor, bool* result);

            public napi_instanceof_delegate napi_instanceof { get; }

            delegate napi_status napi_get_cb_info_delegate(IntPtr env, IntPtr cbinfo, ulong* argc, IntPtr argv, IntPtr this_arg, IntPtr data);

            public napi_get_cb_info_delegate napi_get_cb_info { get; }

            delegate napi_status napi_get_new_target_delegate(IntPtr env, IntPtr cbinfo, IntPtr result);

            public napi_get_new_target_delegate napi_get_new_target { get; }

            delegate napi_status napi_define_class_delegate(IntPtr env, string utf8name, ulong length, IntPtr constructor, void* data, ulong property_count, IntPtr properties, IntPtr result);

            public napi_define_class_delegate napi_define_class { get; }

            delegate napi_status napi_wrap_delegate(IntPtr env, IntPtr js_object, IntPtr native_object, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

            public napi_wrap_delegate napi_wrap { get; }

            delegate napi_status napi_unwrap_delegate(IntPtr env, IntPtr js_object, void** result);

            public napi_unwrap_delegate napi_unwrap { get; }

            delegate napi_status napi_remove_wrap_delegate(IntPtr env, IntPtr js_object, void** result);

            public napi_remove_wrap_delegate napi_remove_wrap { get; }

            delegate napi_status napi_create_external_delegate(IntPtr env, IntPtr data, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

            public napi_create_external_delegate napi_create_external { get; }

            delegate napi_status napi_get_value_external_delegate(IntPtr env, IntPtr value, void** result);

            public napi_get_value_external_delegate napi_get_value_external { get; }

            delegate napi_status napi_create_reference_delegate(IntPtr env, IntPtr value, uint initial_refcount, IntPtr result);

            public napi_create_reference_delegate napi_create_reference { get; }

            delegate napi_status napi_delete_reference_delegate(IntPtr env, IntPtr @ref);

            public napi_delete_reference_delegate napi_delete_reference { get; }

            delegate napi_status napi_reference_ref_delegate(IntPtr env, IntPtr @ref, uint* result);

            public napi_reference_ref_delegate napi_reference_ref { get; }

            delegate napi_status napi_reference_unref_delegate(IntPtr env, IntPtr @ref, uint* result);

            public napi_reference_unref_delegate napi_reference_unref { get; }

            delegate napi_status napi_get_reference_value_delegate(IntPtr env, IntPtr @ref, IntPtr result);

            public napi_get_reference_value_delegate napi_get_reference_value { get; }

            delegate napi_status napi_open_handle_scope_delegate(IntPtr env, IntPtr result);

            public napi_open_handle_scope_delegate napi_open_handle_scope { get; }

            delegate napi_status napi_close_handle_scope_delegate(IntPtr env, IntPtr scope);

            public napi_close_handle_scope_delegate napi_close_handle_scope { get; }

            delegate napi_status napi_open_escapable_handle_scope_delegate(IntPtr env, IntPtr result);

            public napi_open_escapable_handle_scope_delegate napi_open_escapable_handle_scope { get; }

            delegate napi_status napi_close_escapable_handle_scope_delegate(IntPtr env, IntPtr scope);

            public napi_close_escapable_handle_scope_delegate napi_close_escapable_handle_scope { get; }

            delegate napi_status napi_escape_handle_delegate(IntPtr env, IntPtr scope, IntPtr escapee, IntPtr result);

            public napi_escape_handle_delegate napi_escape_handle { get; }

            delegate napi_status napi_throw_delegate(IntPtr env, IntPtr error);

            public napi_throw_delegate napi_throw { get; }

            delegate napi_status napi_throw_error_delegate(IntPtr env, string code, string msg);

            public napi_throw_error_delegate napi_throw_error { get; }

            delegate napi_status napi_throw_type_error_delegate(IntPtr env, string code, string msg);

            public napi_throw_type_error_delegate napi_throw_type_error { get; }

            delegate napi_status napi_throw_range_error_delegate(IntPtr env, string code, string msg);

            public napi_throw_range_error_delegate napi_throw_range_error { get; }

            delegate napi_status napi_is_error_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_error_delegate napi_is_error { get; }

            delegate napi_status napi_is_exception_pending_delegate(IntPtr env, bool* result);

            public napi_is_exception_pending_delegate napi_is_exception_pending { get; }

            delegate napi_status napi_get_and_clear_last_exception_delegate(IntPtr env, IntPtr result);

            public napi_get_and_clear_last_exception_delegate napi_get_and_clear_last_exception { get; }

            delegate napi_status napi_is_arraybuffer_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_arraybuffer_delegate napi_is_arraybuffer { get; }

            delegate napi_status napi_create_arraybuffer_delegate(IntPtr env, ulong byte_length, void** data, IntPtr result);

            public napi_create_arraybuffer_delegate napi_create_arraybuffer { get; }

            delegate napi_status napi_create_external_arraybuffer_delegate(IntPtr env, IntPtr external_data, ulong byte_length, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

            public napi_create_external_arraybuffer_delegate napi_create_external_arraybuffer { get; }

            delegate napi_status napi_get_arraybuffer_info_delegate(IntPtr env, IntPtr arraybuffer, void** data, ulong* byte_length);

            public napi_get_arraybuffer_info_delegate napi_get_arraybuffer_info { get; }

            delegate napi_status napi_is_typedarray_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_typedarray_delegate napi_is_typedarray { get; }

            delegate napi_status napi_create_typedarray_delegate(IntPtr env, napi_typedarray_type type, ulong length, IntPtr arraybuffer, ulong byte_offset, IntPtr result);

            public napi_create_typedarray_delegate napi_create_typedarray { get; }

            delegate napi_status napi_get_typedarray_info_delegate(IntPtr env, IntPtr typedarray, napi_typedarray_type* type, ulong* length, void** data, IntPtr arraybuffer, ulong* byte_offset);

            public napi_get_typedarray_info_delegate napi_get_typedarray_info { get; }

            delegate napi_status napi_create_dataview_delegate(IntPtr env, ulong length, IntPtr arraybuffer, ulong byte_offset, IntPtr result);

            public napi_create_dataview_delegate napi_create_dataview { get; }

            delegate napi_status napi_is_dataview_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_dataview_delegate napi_is_dataview { get; }

            delegate napi_status napi_get_dataview_info_delegate(IntPtr env, IntPtr dataview, ulong* bytelength, void** data, IntPtr arraybuffer, ulong* byte_offset);

            public napi_get_dataview_info_delegate napi_get_dataview_info { get; }

            delegate napi_status napi_get_version_delegate(IntPtr env, uint* result);

            public napi_get_version_delegate napi_get_version { get; }

            delegate napi_status napi_create_promise_delegate(IntPtr env, IntPtr deferred, IntPtr promise);

            public napi_create_promise_delegate napi_create_promise { get; }

            delegate napi_status napi_resolve_deferred_delegate(IntPtr env, IntPtr deferred, IntPtr resolution);

            public napi_resolve_deferred_delegate napi_resolve_deferred { get; }

            delegate napi_status napi_reject_deferred_delegate(IntPtr env, IntPtr deferred, IntPtr rejection);

            public napi_reject_deferred_delegate napi_reject_deferred { get; }

            delegate napi_status napi_is_promise_delegate(IntPtr env, IntPtr value, bool* is_promise);

            public napi_is_promise_delegate napi_is_promise { get; }

            delegate napi_status napi_run_script_delegate(IntPtr env, IntPtr script, IntPtr result);

            public napi_run_script_delegate napi_run_script { get; }

            delegate napi_status napi_adjust_external_memory_delegate(IntPtr env, long change_in_bytes, long* adjusted_value);

            public napi_adjust_external_memory_delegate napi_adjust_external_memory { get; }

            delegate napi_status napi_create_date_delegate(IntPtr env, double time, IntPtr result);

            public napi_create_date_delegate napi_create_date { get; }

            delegate napi_status napi_is_date_delegate(IntPtr env, IntPtr value, bool* is_date);

            public napi_is_date_delegate napi_is_date { get; }

            delegate napi_status napi_get_date_value_delegate(IntPtr env, IntPtr value, double* result);

            public napi_get_date_value_delegate napi_get_date_value { get; }

            delegate napi_status napi_add_finalizer_delegate(IntPtr env, IntPtr js_object, IntPtr native_object, IntPtr finalize_cb, IntPtr finalize_hint, IntPtr result);

            public napi_add_finalizer_delegate napi_add_finalizer { get; }

            delegate napi_status napi_create_bigint_int64_delegate(IntPtr env, long value, IntPtr result);

            public napi_create_bigint_int64_delegate napi_create_bigint_int64 { get; }

            delegate napi_status napi_create_bigint_uint64_delegate(IntPtr env, ulong value, IntPtr result);

            public napi_create_bigint_uint64_delegate napi_create_bigint_uint64 { get; }

            delegate napi_status napi_create_bigint_words_delegate(IntPtr env, int sign_bit, ulong word_count, ulong* words, IntPtr result);

            public napi_create_bigint_words_delegate napi_create_bigint_words { get; }

            delegate napi_status napi_get_value_bigint_int64_delegate(IntPtr env, IntPtr value, long* result, bool* lossless);

            public napi_get_value_bigint_int64_delegate napi_get_value_bigint_int64 { get; }

            delegate napi_status napi_get_value_bigint_uint64_delegate(IntPtr env, IntPtr value, ulong* result, bool* lossless);

            public napi_get_value_bigint_uint64_delegate napi_get_value_bigint_uint64 { get; }

            delegate napi_status napi_get_value_bigint_words_delegate(IntPtr env, IntPtr value, int* sign_bit, ulong* word_count, ulong* words);

            public napi_get_value_bigint_words_delegate napi_get_value_bigint_words { get; }

            delegate napi_status napi_get_all_property_names_delegate(IntPtr env, IntPtr @object, napi_key_collection_mode key_mode, napi_key_filter key_filter, napi_key_conversion key_conversion, IntPtr result);

            public napi_get_all_property_names_delegate napi_get_all_property_names { get; }

            delegate napi_status napi_set_instance_data_delegate(IntPtr env, IntPtr data, IntPtr finalize_cb, IntPtr finalize_hint);

            public napi_set_instance_data_delegate napi_set_instance_data { get; }

            delegate napi_status napi_get_instance_data_delegate(IntPtr env, void** data);

            public napi_get_instance_data_delegate napi_get_instance_data { get; }

            delegate napi_status napi_detach_arraybuffer_delegate(IntPtr env, IntPtr arraybuffer);

            public napi_detach_arraybuffer_delegate napi_detach_arraybuffer { get; }

            delegate napi_status napi_is_detached_arraybuffer_delegate(IntPtr env, IntPtr value, bool* result);

            public napi_is_detached_arraybuffer_delegate napi_is_detached_arraybuffer { get; }

            delegate napi_status napi_type_tag_object_delegate(IntPtr env, IntPtr value, IntPtr type_tag);

            public napi_type_tag_object_delegate napi_type_tag_object { get; }

            delegate napi_status napi_check_object_type_tag_delegate(IntPtr env, IntPtr value, IntPtr type_tag, bool* result);

            public napi_check_object_type_tag_delegate napi_check_object_type_tag { get; }

            delegate napi_status napi_object_freeze_delegate(IntPtr env, IntPtr @object);

            public napi_object_freeze_delegate napi_object_freeze { get; }

            delegate napi_status napi_object_seal_delegate(IntPtr env, IntPtr @object);

            public napi_object_seal_delegate napi_object_seal { get; }
        }
    }
}