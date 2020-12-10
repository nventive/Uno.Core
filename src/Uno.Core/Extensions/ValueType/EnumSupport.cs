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

namespace Uno.Extensions.ValueType
{
	public class EnumSupport<T> : ValueSupport<T>
	{
		private readonly IValueSupport support;

		public EnumSupport()
		{
			var type = Enum.GetUnderlyingType(typeof (T));

			support = ValueSupport.Get(type);
		}

		protected override T CoreAnd(T lhs, T rhs) => (T) support.And(lhs, rhs);

		protected override T CoreXor(T lhs, T rhs) => (T) support.Xor(lhs, rhs);

		protected override T CoreAdd(T lhs, T rhs) => CoreOr(lhs, rhs);

		protected override T CoreSubstract(T lhs, T rhs) => (T) support.And(lhs, support.Not(rhs));

		protected override T CoreOr(T lhs, T rhs) => (T) support.Or(lhs, rhs);

		protected override T CoreNot(T instance) => (T) support.Not(instance);
	}
}
