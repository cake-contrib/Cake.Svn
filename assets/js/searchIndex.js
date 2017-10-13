
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"SvnTool",
        content:"SvnTool",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"SvnExporter",
        content:"SvnExporter",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"SvnLineStyle",
        content:"SvnLineStyle",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"SvnRemoteSettings",
        content:"SvnRemoteSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"SvnCredentials",
        content:"SvnCredentials",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"SvnDepth",
        content:"SvnDepth",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"ISvnClient",
        content:"ISvnClient",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"SvnExportSettings",
        content:"SvnExportSettings",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"SvnAliases",
        content:"SvnAliases",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"SvnSettings",
        content:"SvnSettings",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"SvnExportResult",
        content:"SvnExportResult",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnTool_1',
        title:"SvnTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn.Export/SvnExporter',
        title:"SvnExporter",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnLineStyle',
        title:"SvnLineStyle",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnRemoteSettings',
        title:"SvnRemoteSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnCredentials',
        title:"SvnCredentials",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnDepth',
        title:"SvnDepth",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/ISvnClient',
        title:"ISvnClient",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn.Export/SvnExportSettings',
        title:"SvnExportSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnAliases',
        title:"SvnAliases",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn/SvnSettings',
        title:"SvnSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/Cake.Svn/api/Cake.Svn.Export/SvnExportResult',
        title:"SvnExportResult",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
