namespace API.Model
{
    public class FunctionResponse
    {
        private bool _success;
        private bool _canShowErrorMessage = false;
        private string _errorMessage = string.Empty;

        public FunctionResponse(bool canShowErrorMessage = true)
        {
            _canShowErrorMessage = canShowErrorMessage;
            _success = true;
        }

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value ?? string.Empty;
                _success = false;
            }
        }

        public bool CanShowErrorMessage
        {
            get { return _canShowErrorMessage; }
            set { _canShowErrorMessage = value; }
        }

        public string ShowErrorMessage()
        {
            if (_canShowErrorMessage && !string.IsNullOrEmpty(_errorMessage))
            {
                return _errorMessage;
            }
            return string.Empty;
        }
    }

    public class FunctionResponse<T> : FunctionResponse
    {
        public FunctionResponse(bool canShowErrorMessage = true) : base(canShowErrorMessage) { }
        public T ResponseData { get; set; }
    }
}