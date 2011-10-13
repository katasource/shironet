using System;

namespace Apache.Shiro.Util
{
	public abstract class AbstractFactory<T> : IFactory<T>
	{
		private T singletonInstance;
		
		public AbstractFactory()
		{
			Singleton = true;
		}
		
		public T Instance
		{
			get
			{
				T instance;
				if (Singleton)
				{
					if (singletonInstance == null)
					{
						singletonInstance = CreateInstance();
					}
					instance = singletonInstance;
				}
				else
				{
					instance = CreateInstance();
				}
				
				if (instance == null)
				{
					throw new NullReferenceException("AbstractFactory.CreateInstance() returned a null object");
				}
				return instance;
			}
		}
		
		public bool Singleton
		{
			get;
			set;
		}
		
		protected abstract T CreateInstance();
	}
}
