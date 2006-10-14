#if dotNet2
using System;
	
namespace Rhino.Mocks
{
    /*
     * Class: MockRepository Generic Methods
     */
    /// <summary>
	/// Creates proxied instances of types.
	/// </summary>
	public partial class MockRepository
    {
        /*
          * Method: CreateMock<T>
          * Create a mock object of type T with strict semantics.
          * Strict semantics means that any call that wasn't explicitly recorded is considered an
          * error and would cause an exception to be thrown. 
          */
        /// <summary>
        /// Creates a mock for the spesified type.
        /// </summary>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T CreateMock<T>(params object[] argumentsForConstructor)
        {
            CreateMockState factory = new CreateMockState(CreateRecordState);
            return (T)CreateMockObject(typeof(T), factory, new Type[0], argumentsForConstructor);
        }

        /*
         * Method: DynamicMock<T>
         * Create a mock object of type T with dynamic semantics.
         * Dynamic semantics means that any call that wasn't explicitly recorded is accepted and a
         * null or zero is returned (if there is a return value).
         */
        /// <summary>
        /// Creates a dynamic mock for the specified type.
        /// </summary>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T DynamicMock<T>(params object[] argumentsForConstructor)
        {
            CreateMockState factory = new CreateMockState(CreateDynamicRecordState);
            return (T)CreateMockObject(typeof(T), factory, new Type[0], argumentsForConstructor);
        }
        
        /// <summary>
        /// Creates a mock object from several types.
        /// </summary>
        public T CreateMultiMock<T>(params Type[] extraTypes)
        {
            return (T)CreateMultiMock(typeof(T), extraTypes);
        }

        /// <summary>
        /// Create a mock object from several types with dynamic semantics.
        /// </summary>
        public T DynamicMultiMock<T>(params Type[] extraTypes)
        {
            return (T)DynamicMultiMock(typeof(T), extraTypes);
        }

        /// <summary>
        /// Create a mock object from several types with partial semantics.
        /// </summary>
        public T PartialMultiMock<T>(params Type[] extraTypes)
        {
            return (T)PartialMultiMock(typeof(T), extraTypes);
        }

        /// <summary>
        /// Create a mock object from several types with strict semantics.
        /// </summary>
        /// <param name="extraTypes">Extra interface types to mock.</param>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T CreateMultiMock<T>(Type[] extraTypes, params object[] argumentsForConstructor)
        {
            return (T)CreateMultiMock(typeof(T), extraTypes, argumentsForConstructor);
        }

        /// <summary>
        /// Create a mock object from several types with dynamic semantics.
        /// </summary>
        /// <param name="extraTypes">Extra interface types to mock.</param>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T DynamicMultiMock<T>(Type[] extraTypes, params object[] argumentsForConstructor)
        {
            return (T)DynamicMultiMock(typeof(T), extraTypes, argumentsForConstructor);
        }

        /// <summary>
        /// Create a mock object from several types with partial semantics.
        /// </summary>
        /// <param name="extraTypes">Extra interface types to mock.</param>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T PartialMultiMock<T>(Type[] extraTypes, params object[] argumentsForConstructor)
        {
            return (T)PartialMultiMock(typeof(T), extraTypes, argumentsForConstructor);
        }

        /*
		 * Method: PartialMock
		 * Create a mock object with from a class that defaults to calling the class methods
         * if no expectation is set on the method.
         * 
		 */
        /// <summary>
        /// Create a mock object with from a class that defaults to calling the class methods
        /// </summary>
        /// <param name="argumentsForConstructor">Arguments for the class' constructor, if mocking a concrete class</param>
        public T PartialMock<T>( params object[] argumentsForConstructor) where T : class
        {
            CreateMockState factory = new CreateMockState(CreatePartialRecordState);
            return (T)CreateMockObject(typeof(T), factory, new Type[0], argumentsForConstructor);
        }
    }
}
#endif