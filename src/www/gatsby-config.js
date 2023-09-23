module.exports = {
    siteMetadata: {
      title: 'Menos Relato',
      shortName: 'Menos Relato',
      header: {
        title: 'Menos Relato',
        url: 'https://menosrelato.org',
        logoUrl: 'https://foo.com',
      },      
      description: '(Description)',
    },
    plugins: [
      {
        resolve: '@primer/gatsby-theme-doctocat',
        options: {
          defaultBranch: 'main',
          icon: './img/icon.svg',
          repoRootPath: '../..'
        },
      },
    ],
  }