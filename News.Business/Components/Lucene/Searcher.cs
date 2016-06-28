﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System.Reflection;
using Lucene.Net.Util;
using System.ComponentModel;
using Version = Lucene.Net.Util.Version;
using News.Business.Components.Managers;
using TNews.Business.Components.Lucene;
using News.Business.Components.Lucene.Attributes;

namespace News.Business.Components.Lucene
{
    public class Searcher<T> : BaseSearcher
        where T : new()
    {
        private string[] indexes;

        private int maxCount = 100;

        public Searcher()
            : base()
        {
            fillIndexes();
        }

        public Searcher(string directoryPath)
            : base(directoryPath)
        {
            fillIndexes();
        }

        public void AddUpdateIndex(T TValue)
        {
            AddUpdateIndex(new List<T> { TValue });
        }

        public void AddUpdateIndex(IEnumerable<T> TList)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (var TValue in TList)
                {
                    addToLuceneIndex(TValue, writer);
                }
                writer.Flush(true, true, true);
            }
            analyzer.Close();
        }

        private void addToLuceneIndex(T TValue, IndexWriter writer)
        {
            var doc = MapTValueToDoc(TValue);
            string id = doc.GetField("Id").StringValue;
            if (!String.IsNullOrEmpty(id))
            {
                var searchQuery = new TermQuery(new Term("Id", id));
                writer.UpdateDocument(searchQuery.Term, doc);
            }
            writer.AddDocument(doc);
        }

        private Document MapTValueToDoc(T TValue)
        {
            var putFunc = new LuceneManager<T>(ExtractorStandardBehaviours<T>.ToDoc);
            return putFunc.MapTValueToDoc(TValue);
        }

        public IList<T> Search(string input, string fieldName = "")
        {
            if (String.IsNullOrEmpty(input))
                input = String.Format("Id:[0 TO {0}]", maxCount);
            else
            {
                var terms = input.Trim().Replace("-", " ").Replace("_", "-").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x =>
                    {
                        string t = x.Trim();
                        return String.Format("(({0}*)^2 {0}~0.6)", t);
                    });
                input = String.Join("AND", terms);
            }
            return search(input, fieldName);
        }

        private IList<T> search(string searchQuery, string searchField = "")
        {
            if (String.IsNullOrEmpty(searchQuery))
            {
                return new List<T>();
            }
            using (var searcher = new IndexSearcher(directory, false))
            {
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                QueryParser parser;

                if (!String.IsNullOrEmpty(searchField))
                {
                    parser = new QueryParser(Version.LUCENE_30, searchField, analyzer);
                }
                else
                {
                    parser = new MultiFieldQueryParser
                        (Version.LUCENE_30, indexes, analyzer);
                }
                var query = parseQuery(searchQuery, parser);
                var hits = searcher.Search(query, HITS_LIMIT).ScoreDocs;
                var results = MapDocToTValue(hits, searcher).ToList();
                analyzer.Close();
                return results;
            }
        }

        private IEnumerable<T> MapDocToTValue(IEnumerable<ScoreDoc> hits,
            IndexSearcher searcher)
        {
            return hits.Select(hit =>
                MapDocToTValue(searcher.Doc(hit.Doc)))
                .ToList();
        }

        private T MapDocToTValue(Document doc)
        {
            var putFunc = new LuceneManager<T>(ExtractorStandardBehaviours<T>.ToTValue);
            return putFunc.MapDocToTValue(doc);
        }

        private void fillIndexes()
        {
            List<string> list = new List<string>();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                var attr = property.GetCustomAttribute<Storable>();
                if (attr == null || attr.Type == Field.Index.NO)
                    continue;
                list.Add(property.Name);
            }
            indexes = list.ToArray();
        }
    }
}