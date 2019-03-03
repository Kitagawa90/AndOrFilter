using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.AndOrFilter
{
    public class AndOrFilter<T>
    {
        /// <summary> 抽出対象 </summary>
        private IEnumerable<T> _TargetData;
        /// <summary> 抽出条件 </summary>
        private Func<T, string, bool> _FilterFunc;
        /// <summary> 抽出文字列 </summary>
        private string _FilterString;
        /// <summary> 抽出結果 </summary>
        public IReadOnlyList<T> Result { get => new ReadOnlyCollection<T>(_Result); }
        /// <summary> 抽出結果 </summary>
        private List<T> _Result = new List<T>();


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetData">抽出対象のデータ</param>
        /// <param name="filterFunc">抽出条件</param>
        /// <param name="filterString">抽出文字列</param>
        public AndOrFilter(IEnumerable<T> targetData, Func<T, string, bool> filterFunc, string filterString)
        {
            _TargetData = targetData;
            _FilterFunc = filterFunc;
            _FilterString = filterString;
        }

        /// <summary>
        /// 検索条件で抽出を行います
        /// </summary>
        /// <returns></returns>
        public void Filter()
        {
            var result = new List<T>();
            var filterStrings = SplitFilterString(_FilterString).ToList();

            foreach (var filterString in filterStrings)
            {
                var andFilter = new AndFilter<T>(_TargetData, _FilterFunc, filterString);
                andFilter.Filter();
                result.AddRange(andFilter.Result);
            }

            _Result = result.Distinct().ToList();
        }

        /// <summary>
        /// 検索条件で抽出を行います
        /// </summary>
        /// <returns></returns>
        public void FilterAsParallel()
        {
            var result = new List<T>();
            var filterStrings = SplitFilterString(_FilterString).ToList();
            var addFilters = new List<AndFilter<T>>();

            foreach (var filterString in filterStrings)
            {
                var andFilter = new AndFilter<T>(_TargetData, _FilterFunc, filterString);
                addFilters.Add(andFilter);
            }

            addFilters.AsParallel().ForAll(x => x.Filter());
            foreach (var item in addFilters)
            {
                result.AddRange(item.Result);
            }

            _Result = result.Distinct().ToList();
        }

        /// <summary>
        /// 抽出文字列も分割します
        /// </summary>
        /// <param name="filterString"></param>
        /// <returns></returns>
        private IEnumerable<string> SplitFilterString(string filterString)
        {
            var result = filterString.Split(AndOrFilterConstant.OR_SAPARATOR);
            foreach (var item in result)
            {
                yield return item.Trim();
            }
        }
    }
}
