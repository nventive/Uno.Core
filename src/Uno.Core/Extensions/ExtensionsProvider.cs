// ******************************************************************
// Copyright � 2015-2020 nventive inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************

using System;
using CommonServiceLocator;

namespace Uno.Extensions
{
	public static class ExtensionsProvider
	{
		public static TService Get<TService, TConcrete>()
			where TConcrete : TService, new()
			where TService : class
		{
			var service = ServiceLocator.IsLocationProviderSet ? ServiceLocator.Current.GetInstance<TService>() : null;

			if (service == null)
			{
				service = new TConcrete();
			}

			return service;
		}

		public static TService Get<TService>(Func<TService> defaultFactory)
			where TService : class
		{
			var service =
				ServiceLocator.IsLocationProviderSet ? ServiceLocator.Current.GetInstance<TService>() : null
				?? defaultFactory();

			return service;
		}
	}
}
